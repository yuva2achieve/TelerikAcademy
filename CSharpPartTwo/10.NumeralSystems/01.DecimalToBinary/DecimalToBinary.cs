using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            var binaries = new List<int>();
            int numberInDecimal = 54;
            while (numberInDecimal > 0)
            {
                binaries.Add(numberInDecimal % 2);
                numberInDecimal /= 2;
            }
            binaries.Reverse();
            foreach (var item in binaries)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
