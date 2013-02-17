using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.NumbersInSpiral
{
    class NumbersInSpiral
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N:");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int number = 1;
            int firstRow = 0;
            int firstColumn = 0;
            int lastRow = n - 1;
            int lastColumn = n - 1;

            while (n * n >= number)
            {
                for (int cols = firstColumn; cols <= lastColumn; cols++)
                {
                    matrix[firstRow, cols] = number;
                    number++;
                }
                firstRow++;
                for (int i = firstRow; i <= lastRow; i++)
                {
                    matrix[i, lastColumn] = number;
                    number++;
                }
                lastColumn--;
                for (int i = lastColumn; i >= firstColumn; i--)
                {
                    matrix[lastRow, i] = number;
                    number++;
                }
                lastRow--;
                for (int i = lastRow; i >= firstRow; i--)
                {
                    matrix[i, firstColumn] = number;
                    number++;
                }
                firstColumn++;
            }
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write("{0,4} ", matrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }
    }
}
