using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _09.DeleteOddLines
{
    class DeleteOddLines
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
            int counter = 1;
            string line = "";
            var myBuilder = new StringBuilder();
            using (myReader)
            {
                while (myReader.EndOfStream == false)
                {
                    line = myReader.ReadLine();
                    if (counter % 2 == 0)
                    {
                        myBuilder.AppendLine(line);
                    }
                    counter++;
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
