using System;
using System.Linq;
using System.Text;

namespace _08.BinaryRepresentation
{
    class BinaryRepresentation
    {
        static void Main(string[] args)
        {
            short shortNum = -15;
            int mask;
            int numAndMask;
            int bit;
            StringBuilder result = new StringBuilder();
            for (int i = 15; i >= 0; i--)
            {
                mask = 1 << i;
                numAndMask = shortNum & mask;
                bit = numAndMask >> i;
                result.Append(bit);
            }
            Console.WriteLine(result);
        }
    }
}
