using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // parse first line
        string[] inputNumbers = Console.ReadLine().Split(' ');

        int nodesNumber = int.Parse(inputNumbers[0]);
        int streetsNumber = int.Parse(inputNumbers[1]);
        int hospitalsNumber = int.Parse(inputNumbers[2]);

        // parse second line
        string[] allHospitals = Console.ReadLine().Split(' ');


        Dictionary<Node, List<Connection>> graph =
            new Dictionary<Node, List<Connection>>();
        Dictionary<int, Node> allNodes = new Dictionary<int, Node>();

        // parse all other lines
        for (int i = 0; i < streetsNumber; i++)
        {
            string[] currentStreet = Console.ReadLine().Split(' ');

            int firstNodeId = int.Parse(currentStreet[0]);
            int secondNodeId = int.Parse(currentStreet[1]);
            int distance = int.Parse(currentStreet[2]);

            if (!allNodes.ContainsKey(firstNodeId))
            {
                allNodes.Add(firstNodeId, new Node(firstNodeId));
            }

            if (!allNodes.ContainsKey(secondNodeId))
            {
                allNodes.Add(secondNodeId, new Node(secondNodeId));
            }

            Node firstNode = allNodes[firstNodeId];
            Node secondNode = allNodes[secondNodeId];

            // adding the nodes to the graph
            // (the points to the map)
            if (!graph.ContainsKey(firstNode))
            {
                graph.Add(firstNode, new List<Connection>());
            }

            if (!graph.ContainsKey(secondNode))
            {
                graph.Add(secondNode, new List<Connection>());
            }

            // adding the connections and weight
            graph[firstNode].Add(new Connection(secondNode, distance));
            graph[secondNode].Add(new Connection(firstNode, distance));
        }

        for (int i = 0; i < allHospitals.Length; i++)
        {
            int currentHospitalId = int.Parse(allHospitals[i]);

            allNodes[currentHospitalId].IsHospital = true;
        }

        long shortestPath = long.MaxValue;

        for (int i = 0; i < allHospitals.Length; i++)
        {
            int currentHospitalId = int.Parse(allHospitals[i]);

            DjikstraAlgo(graph, allNodes[currentHospitalId]);

            long currentPath = 0;

            foreach (var node in allNodes)
            {
                if (!node.Value.IsHospital)
                {
                    currentPath += node.Value.DjikstraDistance;
                }
            }

            if (currentPath < shortestPath)
            {
                shortestPath = currentPath;
            }
        }

        Console.WriteLine(shortestPath);
    }

    static void DjikstraAlgo(Dictionary<Node, List<Connection>> graph, Node source)
    {
        PriorityQueue<Node> queue = new PriorityQueue<Node>();

        foreach (var node in graph)
        {
            node.Key.DjikstraDistance = long.MaxValue;
        }

        source.DjikstraDistance = 0;
        queue.Enqueue(source);

        while (queue.Count != 0)
        {
            Node currentNode = queue.Dequeue();

            if (currentNode.DjikstraDistance == long.MaxValue)
            {
                break;
            }

            foreach (var connection in graph[currentNode])
            {
                var potDistance = currentNode.DjikstraDistance + connection.Distance;

                if (potDistance < connection.ToNode.DjikstraDistance)
                {
                    connection.ToNode.DjikstraDistance = potDistance;
                    queue.Enqueue(connection.ToNode);
                }
            }
        }
    }
}