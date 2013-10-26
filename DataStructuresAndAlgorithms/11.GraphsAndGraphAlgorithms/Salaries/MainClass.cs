using System;
using System.Collections.Generic;
using System.Linq;

namespace Salaries
{
    class MainClass
    {
        private static long[] salaries;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] adjacencyMatrix = new string[n, n];
            Dictionary<int, List<int>> connections = new Dictionary<int, List<int>>();

            ProcessInput(n, adjacencyMatrix);

            ListConnections(n, connections, adjacencyMatrix);

            salaries = new long[n];

            long totalSalariesSum = 0;
            for (int i = 0; i < n; i++)
            {
                totalSalariesSum += CalculateSalary(i, connections);   
            }

            Console.WriteLine(totalSalariesSum);
        }

        private static long CalculateSalary(int boss, Dictionary<int, List<int>> connections)
        {
            long salary = 0;
            if (salaries[boss] != 0)
            {
                return salaries[boss];
            }

            if (connections[boss].Count == 0)
            {
                salaries[boss] = 1;
                return 1;
            }
            else
            {
                foreach (var subordinate in connections[boss])
                {
                    long subordinateSalary;
                    if (salaries[subordinate] != 0)
                    {
                        subordinateSalary = salaries[subordinate];
                    }
                    else
                    {
                        subordinateSalary = CalculateSalary(subordinate, connections);
                        salaries[subordinate] = subordinateSalary;
                    }

                    salary += subordinateSalary;
                }
            }

            salaries[boss] = salary;
            return salary;
        }

        private static void ListConnections(int n, Dictionary<int, List<int>> connections, string[,] adjacencyMatrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (!connections.ContainsKey(row))
                    {
                        connections.Add(row, new List<int>());
                    }

                    if (adjacencyMatrix[row, col] == "Y")
                    {
                        connections[row].Add(col);
                    }
                }
            }
        }
  
        private static void ProcessInput(int n, string[,] adjacencyMatrix)
        {
            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    adjacencyMatrix[row, col] = line[col].ToString();
                }
            }
        }
    }
}
