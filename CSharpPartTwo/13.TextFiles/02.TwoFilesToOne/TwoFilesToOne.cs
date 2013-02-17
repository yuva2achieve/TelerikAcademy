using System;
using System.Linq;
using System.Text;
using System.IO;

namespace _02.TwoFilesToOne
{
    class TwoFilesToOne
    {
        static void Main(string[] args)
        {
            string firstFilePath = @"..\..\file1.txt";
            string secondFilePath = @"..\..\file2.txt";
            string outputFilePath = @"..\..\result.txt";
            string output = "";
            StringBuilder myBuilder = new StringBuilder();
            output = ReadFromFile(firstFilePath);
            myBuilder.Append(output);
            output = ReadFromFile(secondFilePath);
            myBuilder.Append(output);
            output = myBuilder.ToString();
            WriteToFile(output, outputFilePath);
        }

        static string ReadFromFile(string path)
        {
            StringBuilder myBuilder = new StringBuilder();
            StreamReader myReader = new StreamReader(path);
            string result;
            using (myReader)
            {
                while (myReader.EndOfStream == false)
                {
                    myBuilder.Append(myReader.ReadLine());
                }
            }
            result = myBuilder.ToString();
            return result;
        }

        static void WriteToFile(string someText, string filePath)
        {
            StreamWriter myWriter = new StreamWriter(filePath);
            using (myWriter)
            {
                myWriter.WriteLine(someText);
            }
            Console.WriteLine("Files are concatenated!");
        }
    }
}
