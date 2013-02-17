using System;
using System.Linq;
using System.Text;
using System.IO;

namespace _07.ReplaceSubstrings
{
    class ReplaceSubstrings
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\file.txt";
            StringBuilder result = ReadFromFile(filePath);
            WriteToFile(result, filePath);
        }

        static StringBuilder ReadFromFile(string path)
        {
            StreamReader myReader = new StreamReader(path);
            string line = "";
            var myBuilder = new StringBuilder();
            using (myReader)
            {
                while (myReader.EndOfStream == false)
                {
                    line = myReader.ReadLine().Replace("start", "finish");
                    myBuilder.Append(line);
                }
            }
            return myBuilder;
        }

        static void WriteToFile(StringBuilder input, string filePath)
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
