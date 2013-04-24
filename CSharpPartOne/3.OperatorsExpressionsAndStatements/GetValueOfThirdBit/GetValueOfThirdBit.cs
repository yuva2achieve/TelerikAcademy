using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetValueOfThirdBit
{
    class GetValueOfThirdBit
    {
        static void Main(string[] args)
        {
            int givenNumber = 35;
            int position = 3;
            int mask = 1 << position;
            int givenNumberAndMask = givenNumber & mask;
            int bit = givenNumberAndMask >> position;
            Console.WriteLine("Bit on position {0} in number {1} is {2}", position, givenNumber, bit);
            
        }
    }
}