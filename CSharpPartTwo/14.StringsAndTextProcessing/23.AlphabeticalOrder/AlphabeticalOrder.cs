using System;
using System.Linq;

namespace _23.AlphabeticalOrder
{
    class AlphabeticalOrder
    {
        static void Main(string[] args)
        {
            string input = "a b ab bc c";
            string[] inputSplit = input.Split(' ');
            Array.Sort(inputSplit);
            foreach (var item in inputSplit)
            {
                Console.WriteLine(item);
            }
        }
    }
}
