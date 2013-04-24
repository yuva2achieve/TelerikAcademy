using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.GreatestCommonDivisor
{
    class GreatestCommonDivisor
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number:");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter second number:");
            int secondNumber = int.Parse(Console.ReadLine());
            int gcd = firstNumber % secondNumber;
            Console.Write("GCD of {0} and {1} is :", firstNumber, secondNumber);
            while (gcd > 0)
            {
                firstNumber = secondNumber;
                secondNumber = gcd;
                gcd = firstNumber % secondNumber;
            }
            Console.Write("{0} \n", secondNumber);
        }
    }
}
