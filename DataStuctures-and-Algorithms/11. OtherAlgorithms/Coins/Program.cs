using System;
using System.Collections.Generic;
using System.Linq;

namespace Coins
{
    class Program
    {
        static void Main()
        {
            List<int> coins = new List<int>();
            List<int> amounts = new List<int>() { 1, 2, 5 };
            int goal = 33;

            Change(coins, amounts, 0, 0, goal);
        }

        static void Change(List<int> coins, List<int> amounts, int highest, int sum, int goal)
        {
            if (sum == goal)
            {
                Display(coins, amounts, goal);
                return;
            }

            if (sum > goal)
            {
                return;
            }

            foreach (int value in amounts)
            {
                if (value >= highest)
                {
                    List<int> copy = new List<int>(coins);
                    copy.Add(value);
                    Change(copy, amounts, value, sum + value, goal);
                }
            }
        }

        static void Display(List<int> coins, List<int> amounts, int goal)
        {
            int total = 0;

            foreach (int amount in amounts)
            {
                int count = coins.Count(value => value == amount);
                Console.Write("{0} coins x {1}", count, amount);

                total++;
                if (total != amounts.Count)
                {
                    Console.Write(" + ");
                }
                else
                {
                    Console.Write(" = {0}", goal);
                }
            }

            Console.WriteLine();
        }
    }
}