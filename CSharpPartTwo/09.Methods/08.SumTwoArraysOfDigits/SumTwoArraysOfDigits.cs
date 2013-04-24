using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SumTwoArraysOfDigits
{
    class SumTwoArraysOfDigits
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
        static List<int> GetReversedSum(List<int> firstNumReversed, List<int> secondNumReversed)
        {
            List<int> sum = new List<int>();
            int sumOfNumbers = 0;
            int remainder = 0;
            if (firstNumReversed.Count != secondNumReversed.Count)
            {                
                AddLeadingZeros(firstNumReversed, secondNumReversed);
            }
            for (int i = 0; i < firstNumReversed.Count; i++)
            {
                if (remainder == 0)
                {
                    sumOfNumbers = firstNumReversed[i] + secondNumReversed[i];
                }
                else
                {
                    sumOfNumbers = firstNumReversed[i] + secondNumReversed[i] + remainder;
                    remainder = 0;
                }
                if (sumOfNumbers > 9)
                {
                    remainder = sumOfNumbers / 10;
                    sum.Add(sumOfNumbers % 10);
                }
                else
                {
                    sum.Add(sumOfNumbers);
                }
            }
            if (remainder != 0)
            {
                sum.Add(remainder);
            }
            return sum;
        }
  
        static void AddLeadingZeros(List<int> firstNumReversed, List<int> secondNumReversed)
        {
            if (firstNumReversed.Count < secondNumReversed.Count)
            {
                for (int i = 0; i < secondNumReversed.Count - firstNumReversed.Count; i++)
                {
                    firstNumReversed.Add(0);
                }
            }
            else
            {
                for (int i = 0; i < firstNumReversed.Count - secondNumReversed.Count; i++)
                {
                    secondNumReversed.Add(0);
                }
            }
            GetReversedSum(firstNumReversed, secondNumReversed);
        }

        static void Main(string[] args)
        {
            int firstNumber = 1500;
            int secondNumber = 500;
            List<int> firstNumberDigits = GetReversedDigits(firstNumber);
            List<int> secondNumberDigits = GetReversedDigits(secondNumber);
            List<int> sumOfNumbers = GetReversedSum(firstNumberDigits, secondNumberDigits);
            foreach (var digit in sumOfNumbers)
            {
                Console.Write("{0} ", digit);
            }
        }
    }
}
