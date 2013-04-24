using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractBitValue
{
    class ExtractBitValue
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter integer value");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter bit position");
            int b = int.Parse(Console.ReadLine());
            int mask = 1 << b;
            int result = i & mask;
            int bitValue = result >> b;
            Console.WriteLine("Bit on position {0} in the number {1} is {2}", b, i, bitValue);
        }
    }
}
