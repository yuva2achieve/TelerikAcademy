using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CompareTwoIntegers
{
    class CompareTwoIntegers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first integer:");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second integer:");
            int secondNumber = int.Parse(Console.ReadLine());
            int numbersSwap;
            if (firstNumber > secondNumber)
            {
                Console.WriteLine("{0} is bigger than {1}", firstNumber, secondNumber);
            }
            else
            {
                numbersSwap = firstNumber;
                firstNumber = secondNumber;
                Console.WriteLine("{0} is bigger than {1}", firstNumber, numbersSwap);
            }
        }
    }
}
