using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _03.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\file1.txt";
            string outputFilePath = @"..\..\output.txt";
            var textContainer = ReadFromFile(filePath);
            WriteToFile(textContainer, outputFilePath);
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

        static void WriteToFile(List<string> inputText, string filePath)
        {
            StreamWriter myWriter = new StreamWriter(filePath);
            using (myWriter)
            {
                for (int i = 1; i <= inputText.Count; i++)
                {
                    myWriter.Write(i + ". ");
                    myWriter.WriteLine(inputText[i - 1]);
                }
            }
            Console.WriteLine("Done!");
        }
    }
}
