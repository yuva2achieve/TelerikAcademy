using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HexToDec
{
    class HexToDec
    {
        static void Main(string[] args)
        {
            string hexNum = "fe";
            hexNum = hexNum.ToUpper();
            var hexNumDigits = new List<int>();
            int tempVariable = 0;
            int result = 0;
            foreach (var item in hexNum)
            {
                switch (item)
                {
                    case 'A': tempVariable = 10; break;
                    case 'B': tempVariable = 11; break;
                    case 'C': tempVariable = 12; break;
                    case 'D': tempVariable = 13; break;
                    case 'E': tempVariable = 14; break;
                    case 'F': tempVariable = 15; break;
                    default: tempVariable = item - '0'; break;
                }
                hexNumDigits.Add(tempVariable);
            }
            hexNumDigits.Reverse();
            for (int i = 0; i < hexNumDigits.Count; i++)
            {
                result += ConvertHexToDec(hexNumDigits[i], i);
            }
            Console.WriteLine(result);
        }

        static int ConvertHexToDec(int num, int toPower)
        {
            int numInDec = 0;
            int numBase = 16;
            if (num != 0)
            {
                numInDec = num * (int)(Math.Pow(numBase, toPower));
                return numInDec;
            }
            return numInDec;
        }
    }
}
