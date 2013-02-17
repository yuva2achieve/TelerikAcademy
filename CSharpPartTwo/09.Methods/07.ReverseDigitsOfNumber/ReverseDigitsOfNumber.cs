using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ReverseDigitsOfNumber
{
    class ReverseDigitsOfNumber
    {
        static List<int> GetReversedDigits(int num)
        {
            string number = Convert.ToString(num);
            List<int> digits = new List<int>();
            foreach (var digit in number)
            {
                digits.Add(digit - '0');
            }
            digits.Reverse();
            return digits;
        }
        static void PrintReversedDigits(List<int> list)
        {
            foreach (var digit in list)
            {
                Console.Write("{0} ", digit);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            PrintReversedDigits(GetReversedDigits(number));
        }
    }
}
