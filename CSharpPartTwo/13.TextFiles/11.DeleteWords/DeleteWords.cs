using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _11.DeleteWords
{
    class DeleteWords
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\file.txt";
            string pattern = @"(\btest)\w+\b";
            StringBuilder result = ReadFromFile(filePath, pattern, "");
            WriteToFile(result, filePath);
        }

        static StringBuilder ReadFromFile(string path, string regEx, string replacement)
        {
            StreamReader myReader = new StreamReader(path);
            string line = "";
            var myBuilder = new StringBuilder();
            using (myReader)
            {
                while (myReader.EndOfStream == false)
                {
                    line = Regex.Replace(myReader.ReadLine(), regEx, replacement);
                    myBuilder.AppendLine(line);
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
