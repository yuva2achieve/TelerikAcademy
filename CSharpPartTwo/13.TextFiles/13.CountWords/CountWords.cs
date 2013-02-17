using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _13.CountWords
{
    class CountWords
    {
        static void Main(string[] args)
        {
            string firstFilePath = @"..\..\file1.txt";//File containing list of words
            string secondFilePath = @"..\..\file2.txt";//Some text
            string outputFilePath = @"..\..\result.txt";//Output file
            var words = new List<string>();
            var wordCount = new List<string>();
            string textInput = "";
            try
            {
                words = ReadFromFile(firstFilePath);
                ReadFromFile(secondFilePath, out textInput);
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
                wordCount = FindMatches(words, textInput, wordCount);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            try
            {
                wordCount = SortMatches(wordCount);
            }
            catch (IndexOutOfRangeException ioor)
            {
                Console.WriteLine(ioor.Message);
            }
            try
            {
                WriteToFile(wordCount, outputFilePath);
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

        /*------------------------------To read first file ----------------------------------------------*/
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

        /*------------------------------To read second file ----------------------------------------------*/
        static void ReadFromFile(string path, out string output)
        {
            StreamReader myReader = new StreamReader(path);
            string line = "";
            StringBuilder myBuilder = new StringBuilder();
            using (myReader)
            {
                while (myReader.EndOfStream == false)
                {
                    line = myReader.ReadLine().ToLower();
                    myBuilder.AppendLine(line);
                }
            }
            output = myBuilder.ToString();
        }

        /*------------------------------Finds matches in the text file----------------------------------*/
        private static List<string> FindMatches(List<string> words, string textInput, List<string> myList)
        {
            MatchCollection wordMatches;
            foreach (var item in words)
            {
                wordMatches = Regex.Matches(textInput, item);
                myList.Add(item + " " + wordMatches.Count);
            }
            return myList;
        }

        /*---------------------------------To sort the matches in descending order-----------------------------------------*/
        private static List<string> SortMatches(List<string> matches)
        {
            string temp = "";
            for (int i = 0; i < matches.Count - 1; i++)
            {
                if (matches[i][matches[i].Length - 1] < matches[i + 1][matches[i + 1].Length - 1])
                {
                    temp = matches[i];
                    matches[i] = matches[i + 1];
                    matches[i + 1] = temp;
                }
            }
            return matches;
        }

        /*------------------------------To write the result ----------------------------------------------*/
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
