using System;
using System.Linq;

namespace _02.SquareWithMaximalSum
{
    class SquareWithMaximalSum
    {
        static void Main(string[] args)
        {
            var myMatrix = new int[4, 5]
            {
                {0,2,1,-2,5},
                {5,3,7,0,-4},
                {-3,4,2,4,1},
                {2,5,-4,0,3}
            };
            int result = GetMaximalPlatformSum(myMatrix);
            Console.WriteLine(result);
        }
        static int GetMaximalPlatformSum(int[,] matrix)
        {
            int bestSum = int.MinValue;
            for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 2; cols++)
                {
                    int sum = matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows, cols + 2] +
                        matrix[rows + 1, cols] + matrix[rows + 1, cols + 1] + matrix[rows + 1, cols + 2] +
                        matrix[rows + 2, cols] + matrix[rows + 2, cols + 1] + matrix[rows + 2, cols + 2];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                    }
                }
            }
            return bestSum;
        }
    }
}
