using System;
using System.Collections.Generic;

public class Program
{
    static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
    {
        PriorityQueue<Node> queue = new PriorityQueue<Node>();

        foreach (var node in graph)
        {
            if (source.ID != node.Key.ID)
            {
                node.Key.DijkstraDistance = double.PositiveInfinity;
                queue.Enqueue(node.Key);
            }
        }

        source.DijkstraDistance = 0.0d;
        queue.Enqueue(source);

        while (queue.Count != 0)
        {
            Node currentNode = queue.Peek();

            if (currentNode.DijkstraDistance == double.PositiveInfinity)
            {
                break;
            }

            foreach (var neighbour in graph[currentNode])
            {
                double potDistance = currentNode.DijkstraDistance + neighbour.Distance;

                if (potDistance < neighbour.ToNode.DijkstraDistance)
                {
                    neighbour.ToNode.DijkstraDistance = potDistance;
                }
            }

            queue.Dequeue();
        }
    }

    static void Main()
    {
        Node cableCompanyHQ = new Node(1);
        Node house1 = new Node(2);
        Node hosue2 = new Node(3);
        Node house3 = new Node(4);
        Node house4 = new Node(5);
        Node house5 = new Node(6);
        Node house6 = new Node(7);
        Node house7 = new Node(8);
        Node house8 = new Node(9);
        Node house9 = new Node(10);

        List<Node> nodes = new List<Node>();

        nodes.Add(cableCompanyHQ);
        nodes.Add(house1);
        nodes.Add(hosue2);
        nodes.Add(house3);
        nodes.Add(house4);
        nodes.Add(house5);
        nodes.Add(house6);
        nodes.Add(house7);
        nodes.Add(house8);
        nodes.Add(house9);

        Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>()
            {
                {cableCompanyHQ, new List<Connection> {new Connection(house1, 23), new Connection(house7, 8), new Connection(house6, 2)} },
                {house1, new List<Connection> {new Connection(cableCompanyHQ, 23), new Connection(house3, 3), new Connection(house6, 34)} },
                {hosue2, new List<Connection> {new Connection(house3, 13), new Connection(house7, 25), new Connection(house9, 10)} },
                {house3, new List<Connection> {new Connection(house1, 3), new Connection(hosue2, 6)} },
                {house4, new List<Connection> {new Connection(house5, 11)} },
                {house5, new List<Connection> {new Connection(house4, 19)} },
                {house6, new List<Connection> {new Connection(house1, 40), new Connection(cableCompanyHQ, 2)} },
                {house7, new List<Connection> {new Connection(cableCompanyHQ, 8), new Connection(hosue2, 30), new Connection(house9, 11)} },
                {house8, new List<Connection> {} },
                {house9, new List<Connection> {new Connection(hosue2, 7), new Connection(house7, 30)} },
            };

        Node source = cableCompanyHQ;

        DijkstraAlgorithm(graph, source);
        int houseCounter = 1;

        for (int i = 1; i < nodes.Count; i++)
        {
            Console.Write("Distance from CableCompany HQ to house {0} is ", houseCounter);
            Console.WriteLine(nodes[i].DijkstraDistance);
            houseCounter++;
        }
    }
}