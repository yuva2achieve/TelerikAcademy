using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ConvertSToD
{
    class ConvertSToD
    {
        static void Main(string[] args)
        {
            Console.WriteLine("S and D must be >= 2 and <= 16");
            Console.Write("Enter S: ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("Enter D: ");
            int d = int.Parse(Console.ReadLine());
            Console.Write("Enter number: ");
            string numberInput = Console.ReadLine();
            var numList = StringToArray(numberInput);
            int numInDecimal = ToDecimal(numList, s);
            if (d != 10)
            {
                ConvertFromDecimal(numInDecimal, d);
            }
            else
            {
                Console.WriteLine(numInDecimal);
            }
        }

        static List<int> StringToArray(string num)
        {
            var numList = new List<int>();
            num = num.ToUpper();
            for (int i = 0; i < num.Length; i++)
            {
                switch (num[i])
                {
                    case 'A': numList.Add(10);break;
                    case 'B': numList.Add(11);break;
                    case 'C': numList.Add(12);break;
                    case 'D': numList.Add(13);break;
                    case 'E': numList.Add(14);break;
                    case 'F': numList.Add(15);break;
                    default:numList.Add( num[i] - '0');break;
                }
            }
            numList.Reverse();
            return numList;
        }

        static int ToDecimal(List<int> myList, int numBase)
        {
            int result = 0;
            int numInDecimal = 0;
            for (int i = 0; i < myList.Count; i++)
            {
                result = myList[i] * (int)(Math.Pow(numBase, i));
                numInDecimal += result;
            }
            return numInDecimal;
        }

        static void ConvertFromDecimal(int numInDec, int convertToBase)
        {
            var digits = new List<int>();
            while (numInDec > 0)
            {
                digits.Add(numInDec % convertToBase);
                numInDec /= convertToBase;
            }
            digits.Reverse();
            Console.Write("Result: ");
            foreach (var item in digits)
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
