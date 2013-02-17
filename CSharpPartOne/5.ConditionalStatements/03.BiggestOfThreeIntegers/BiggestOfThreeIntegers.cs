using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BiggestOfThreeIntegers
{
    class BiggestOfThreeIntegers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number:");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter third number:");
            int thirdNumber = int.Parse(Console.ReadLine());
            if (firstNumber > secondNumber)
            {
                if (firstNumber > thirdNumber)
                {
                    Console.WriteLine("a");
                } 
            }
            if (secondNumber > firstNumber)
            {
                if (secondNumber > thirdNumber)
                {
                    Console.WriteLine("b");
                }
            }
            if (thirdNumber > firstNumber)
            {
                if (thirdNumber > secondNumber)
                {
                    Console.WriteLine("c");
                }
            }
        }
    }
}
