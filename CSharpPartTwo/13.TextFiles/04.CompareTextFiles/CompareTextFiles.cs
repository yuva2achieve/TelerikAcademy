using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _04.CompareTextFiles
{
    class CompareTextFiles
    {
        static void Main(string[] args)
        {
            string firstFilePath = @"..\..\file1.txt";
            string secondFilePath = @"..\..\file2.txt";
            var firstFile = ReadFromFile(firstFilePath);
            var secondFile = ReadFromFile(secondFilePath);
            CompareFiles(firstFile, secondFile);
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

        static void CompareFiles(List<string> file1, List<string> file2)
        {
            int sameLines = 0;
            int differentLines = 0;
            bool equals = false;
            for (int i = 0; i < file1.Count; i++)
            {
                equals = String.Equals(file1[i], file2[i]);
                if (equals)
                {
                    sameLines++;
                }
                else
                {
                    differentLines++;
                }
            }
            Console.WriteLine("Same lines: {0}", sameLines);
            Console.WriteLine("Different lines: {0}", differentLines);
        }
    }
}
