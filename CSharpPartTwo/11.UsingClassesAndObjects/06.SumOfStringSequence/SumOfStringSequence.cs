using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SumOfStringSequence
{
    class SumOfStringSequence
    {
        static void Main(string[] args)
        {
            string sequence = "43 68 9 23 318";
            var sequenceItems = new List<int>();
            var str = sequence.Split(' ');
            foreach (var item in str)
            {
                sequenceItems.Add(int.Parse(item));
            }
            Console.WriteLine(sequenceItems.Sum());
        }
    }
}
