using System;
using System.Linq;

namespace _09.LargestPassableAreaInMatrix
{
    class Program
    {
        private const string Passable = "P";
        private const string Obstacle = "X";
        private static string[,] matrix =
                {
                    {Passable, Obstacle, Passable, Passable},
                    {Passable, Obstacle, Passable, Passable},
                    {Passable, Obstacle, Obstacle, Passable},
                    {Passable, Passable, Passable, Passable},
                    {Passable, Passable, Obstacle, Passable},
                };

        private static int currentCount = 0;
        private static int maxCount = int.MinValue;

        static void Main(string[] args)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == Passable)
                    {
                        Traverse(row, col);
                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                        }

                        currentCount = 0;
                    }

                }
            }

            PrintResult();
        }

        private static void Traverse(int startRowIndex, int startColIndex)
        {
            bool indexIsNegative = startRowIndex < 0 || startColIndex < 0;
            bool indexIsOutOfRange = startRowIndex >= matrix.GetLength(0) || startColIndex >= matrix.GetLength(1);
            
            if (indexIsNegative || indexIsOutOfRange)
            {
                return;
            }

            if (matrix[startRowIndex, startColIndex] != Passable)
            {
                return;
            }

            currentCount++;
            matrix[startRowIndex, startColIndex] = currentCount.ToString();

            Traverse(startRowIndex, startColIndex - 1);
            Traverse(startRowIndex, startColIndex + 1);
            Traverse(startRowIndex - 1, startColIndex);
            Traverse(startRowIndex + 1, startColIndex);
        }

        private static void PrintResult()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + "\t");
                }

                Console.WriteLine();
            }
        }
    }
}
