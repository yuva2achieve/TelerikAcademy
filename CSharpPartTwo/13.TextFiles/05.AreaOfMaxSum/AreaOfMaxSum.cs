using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _05.AreaOfMaxSum
{
    class AreaOfMaxSum
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\file1.txt";
            string outputFilePath = @"..\..\output.txt";
            var fileLines = ReadFromFile(filePath);
            int matrixSize = int.Parse(fileLines[0]); 
            int[,] matrix = new int[matrixSize, matrixSize];
            matrix = FillMatrix(fileLines, matrix);
            int result = GetMaximalPlatformSum(matrix);
            WriteToFile(result, outputFilePath);
        }

        static List<string> ReadFromFile(string path)
        {
            StreamReader myReader = new StreamReader(path);
            var result = new List<string>();
            using (myReader)
            {
                while (myReader.EndOfStream == false)
                {
                    result.Add(myReader.ReadLine());
                }
            }
            return result;
        }

        static int[,] FillMatrix(List<string> stringContent,int[,] emptyMatrix)
        {
            string[] splitted;
            int rows = 0;
            for (int j = 1; j < stringContent.Count;j++)
            {
                splitted = stringContent[j].Split(' ');
                for (int i = 0; i < splitted.Length; i++)
                {
                    emptyMatrix[rows, i] = int.Parse(splitted[i]);
                }
                rows++;
            }
            return emptyMatrix;
        }

        static int GetMaximalPlatformSum(int[,] matrix)
        {
            int bestSum = int.MinValue;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    int sum = matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows + 1, cols] +
                        matrix[rows + 1, cols + 1];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                    }
                }
            }
            return bestSum;
        }

        static void WriteToFile(int input, string filePath)
        {
            StreamWriter myWriter = new StreamWriter(filePath);
            using (myWriter)
            {
                myWriter.WriteLine(input);
            }
            Console.WriteLine("Done!");
        }
    }
}
