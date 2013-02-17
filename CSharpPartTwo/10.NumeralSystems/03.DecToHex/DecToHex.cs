using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.DecToHex
{
    class DecToHex
    {
        static void Main(string[] args)
        {
            var hexDigits = new List<int>();
            int numberInDec = 1117;
            while (numberInDec > 0)
            {
                hexDigits.Add(numberInDec % 16);
                numberInDec /= 16;
            }
            hexDigits.Reverse();
            foreach (var item in hexDigits)
            {
                if (item < 10)
                {
                    Console.Write(item);
                }
                else
                {
                    switch (item)
                    {
                        case 10: Console.Write("A"); break;
                        case 11: Console.Write("B"); break;
                        case 12: Console.Write("C"); break;
                        case 13: Console.Write("D"); break;
                        case 14: Console.Write("E"); break;
                        case 15: Console.Write("F"); break;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
