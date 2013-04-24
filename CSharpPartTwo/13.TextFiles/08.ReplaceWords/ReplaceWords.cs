using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace _08.ReplaceWords
{
    class ReplaceWords
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\file.txt";
            string pattern = @"\bstart\b";
            string replacement = "finish";
            StringBuilder result = ReadFromFile(filePath,pattern, replacement);
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
