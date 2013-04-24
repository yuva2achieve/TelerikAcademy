using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace _10.GetTextFromXml
{
    class GetTextFromXml
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\file.txt";
            string pattern = @"<[^<]+?>";
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
