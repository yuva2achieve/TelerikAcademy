using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _12.RemoveListedWords
{
    class RemoveListedWords
    {
        static void Main(string[] args)
        {
            string firstFilePath = @"..\..\file.txt";
            string secondFilePath = @"..\..\file2.txt";
            var firstFile = new List<string>();
            StringBuilder secondFile = new StringBuilder();
            try
            {
                firstFile = ReadFromFile(firstFilePath);
                secondFile = ReadFromFile(secondFilePath, firstFile);
            }
            catch (OutOfMemoryException ooe)
            {
                Console.WriteLine(ooe.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            try
            {
                WriteToFile(secondFile, secondFilePath);
            }
            catch (ObjectDisposedException ode)
            {
                Console.WriteLine(ode.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
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

        static StringBuilder ReadFromFile(string path, List<string> wordsToRemove)
        {
            StreamReader myReader = new StreamReader(path);
            string line = "";
            var myBuilder = new StringBuilder();
            using (myReader)
            {
                while (myReader.EndOfStream == false)
                {
                    line = myReader.ReadLine().ToLower();
                    foreach (var word in wordsToRemove)
                    {
                        line = line.Replace(word, "");
                    }
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
