using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SortSequenceInIncreasingOrder
{
    class MainClass
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>();
            GetSequence(sequence);

            // Using LINQ
            var sortedSequence =
                        from item in sequence
                        orderby item ascending
                        select item;
            PrintSortedSequence(sortedSequence);

            // Using Sort()
            //sequence.Sort();
            //PrintSortedSequence(sequence);

            // Using OrderBy()
            //var sortedSequence = sequence.OrderBy(x => x).ToList();
            //PrintSortedSequence(sortedSequence);

        }
  
        private static void PrintSortedSequence(IEnumerable<int> sortedSequence)
        {
            foreach (var item in sortedSequence)
            {
                Console.Write("{0} ", item);
            }
        }

        private static void GetSequence(List<int> sequence)
        {
            bool sequenceFinished = false;
            while (!sequenceFinished)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    sequenceFinished = true;
                }
                else
                {
                    int inputValue = int.Parse(input);
                    sequence.Add(inputValue);
                }
            }
        }
    }
}
