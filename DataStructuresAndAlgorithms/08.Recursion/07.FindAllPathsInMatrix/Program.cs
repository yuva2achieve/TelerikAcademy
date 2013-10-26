using System;
using System.Linq;

namespace _07.FindAllPathsInMatrix
{
    class Program
    {
        private const string Passable = "P";
        private const string Obstacle = "X";
        private const string Exit = "E";
        private static string[,] matrix =
                {
                    {Passable, Obstacle, Passable, Passable},
                    {Passable, Obstacle, Passable, Passable},
                    {Passable, Obstacle, Obstacle, Exit},
                    {Passable, Passable, Passable, Passable},
                    {Passable, Passable, Obstacle, Passable},
                };

        private static int pathsCount = 0;

        static void Main(string[] args)
        {
            Traverse(0, 0, 0);
        }

        private static void Traverse(int startRowIndex, int startColIndex, int step)
        {
            bool indexIsNegative = startRowIndex < 0 || startColIndex < 0;
            bool indexIsOutOfRange = startRowIndex >= matrix.GetLength(0) || startColIndex >= matrix.GetLength(1);
            if (indexIsNegative || indexIsOutOfRange)
            {
                return;
            }

            if (matrix[startRowIndex, startColIndex] == Exit)
            {
                pathsCount++;
                PrintPath();
                return;
            }

            if (matrix[startRowIndex,startColIndex] != Passable)
            {
                return;
            }


            matrix[startRowIndex, startColIndex] = step.ToString();

            Traverse(startRowIndex, startColIndex - 1, step + 1);
            Traverse(startRowIndex, startColIndex + 1, step + 1);
            Traverse(startRowIndex - 1, startColIndex, step + 1);
            Traverse(startRowIndex + 1, startColIndex, step + 1);

            matrix[startRowIndex, startColIndex] = Passable;
        }

        private static void PrintPath()
        {
            Console.WriteLine("Path number: {0}", pathsCount);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row,col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
