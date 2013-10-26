using System;
using System.Linq;

namespace _08.CheckIfPathExists
{
    class Program
    {
        private const string Passable = "P";
        private const string Obstacle = "X";
        private const string Exit = "E";
        private static string[,] matrix = new string[100, 100];

        static void Main(string[] args)
        {
            FillMatrix();
            SetExit(99, 99);
            bool hasPath = false;
            Traverse(0, 0, ref hasPath);
            Console.WriteLine("Has path: {0}", hasPath);
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = Passable;
                }
            }
        }

        private static void SetExit(int rowIndex, int colIndex)
        {
            matrix[rowIndex, colIndex] = Exit;
        }

        private static void Traverse(int startRowIndex, int startColIndex, ref bool pathFound)
        {
            bool indexIsNegative = startRowIndex < 0 || startColIndex < 0;
            bool indexIsOutOfRange = startRowIndex >= matrix.GetLength(0) || startColIndex >= matrix.GetLength(1);
            if (indexIsNegative || indexIsOutOfRange || pathFound)
            {
                return;
            }

            if (matrix[startRowIndex, startColIndex] == Exit)
            {
                pathFound = true;
                return;
            }

            if (matrix[startRowIndex, startColIndex] != Passable)
            {
                return;
            }


            matrix[startRowIndex, startColIndex] = Obstacle;

            Traverse(startRowIndex, startColIndex - 1,ref pathFound);
            Traverse(startRowIndex, startColIndex + 1,ref pathFound);
            Traverse(startRowIndex - 1, startColIndex,ref pathFound);
            Traverse(startRowIndex + 1, startColIndex,ref pathFound);

            matrix[startRowIndex, startColIndex] = Passable;
        }
    }
}
