using System;
using System.Linq;

namespace _01.PrintMatrices
{
    class PrintMatrices
    {
        static void Main(string[] args)
        {
            var myMatrix = new int[4, 4];
            PrintMatrixA(0, 0, 1, myMatrix);
            Console.WriteLine();
            PrintMatrixB(0, 0, 1, myMatrix);
        }

        static void PrintMatrixA(int rows,int cols, int counter, int[,] matrix)
        {
            if (cols == matrix.GetLength(1))
            {
                Print(matrix);
            }
            else
            {
                int c = counter;
                for (int i = rows; i < matrix.GetLength(0); i++)
                {
                    matrix[i, cols] = c;
                    c++;
                }
                PrintMatrixA(rows, cols + 1, c, matrix);
            }
            
        }

        static void PrintMatrixB(int rows, int cols, int counter, int[,] matrix)
        {
            int c = counter;
            if (cols == matrix.GetLength(1))
            {
                Print(matrix);
            }
            else
            {
                if (cols % 2 == 0)
                {
                    for (int i = rows; i < matrix.GetLength(0); i++)
                    {
                        matrix[i, cols] = c;
                        c++;
                    }
                    PrintMatrixB(matrix.GetLength(0) - 1, cols + 1, c, matrix);
                }
                else if (cols % 2 == 1)
                {
                    for (int i = rows; i >= 0; i--)
                    {
                        matrix[i, cols] = c;
                        c++;
                    }
                    PrintMatrixB(0, cols + 1, c, matrix);
                }
            }
        }
  
        static void Print(int[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write(matrix[rows,cols] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
