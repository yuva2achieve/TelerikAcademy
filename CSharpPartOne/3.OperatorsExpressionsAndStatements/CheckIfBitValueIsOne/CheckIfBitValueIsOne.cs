using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIfBitValueIsOne
{
    class CheckIfBitValueIsOne
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter integer value");
            int v = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter bit position");
            int p = int.Parse(Console.ReadLine());
            int mask = 1 << p;
            int result = v & mask;
            int bit = result >> p;
            bool isOne = false;
            if (bit == 1)
            {
                isOne = true;
            }
            Console.WriteLine("Bit on position {0} in the number {1} is one?: {2}", p, v, isOne);
        }
    }
}
