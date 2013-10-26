using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.CountWordOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = @"../../words.txt";
            StreamReader myReader = new StreamReader(inputFile);
            Dictionary<string, int> occurrencesCount = new Dictionary<string, int>();
            using (myReader)
            {
                while (!myReader.EndOfStream)
                {
                    string line = myReader.ReadLine();
                    string[] words = line.Split(new char[] { ' ', '.', '!', ',', '?' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        if (occurrencesCount.ContainsKey(word.ToLower()))
                        {
                            occurrencesCount[word.ToLower()]++;
                        }
                        else
                        {
                            occurrencesCount.Add(word.ToLower(), 1);
                        }
                    }
                }
            }

            var sortedByOccurrenceCount =
                (from keyValuePair in occurrencesCount
                orderby keyValuePair.Value ascending
                select keyValuePair).ToList();

            foreach (var item in sortedByOccurrenceCount)
            {
                Console.WriteLine(item);
            }
        }
    }
}
