using System;
using System.Linq;

namespace _02.BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main(string[] args)
        {
            int[] binary = { 1, 0, 0};
            Array.Reverse(binary);
            int numInDecimal = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                numInDecimal += ConvertToDecimal(binary[i], i);
            }
            Console.WriteLine(numInDecimal);
        }

        static int ConvertToDecimal(int num, int toPower)
        {
            int result = 0;
            int numBase = 2;
            if (num != 0)
            {
                result = num * (int)(Math.Pow(numBase, toPower));
            }
            return result;
        }
    }
}
