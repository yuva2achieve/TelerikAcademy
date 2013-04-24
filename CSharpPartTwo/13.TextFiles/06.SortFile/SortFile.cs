using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _06.SortFile
{
    class SortFile
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\file1.txt";
            string outputFilePath = @"..\..\output.txt";
            var inputContent = ReadFromFile(filePath);
            inputContent.Sort();
            WriteToFile(inputContent, outputFilePath);
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

        static void WriteToFile(List<string> input, string filePath)
        {
            StreamWriter myWriter = new StreamWriter(filePath);
            using (myWriter)
            {
                foreach (var item in input)
                {
                    myWriter.WriteLine(item);
                }
            }
            Console.WriteLine("Done!");
        }
    }
}
