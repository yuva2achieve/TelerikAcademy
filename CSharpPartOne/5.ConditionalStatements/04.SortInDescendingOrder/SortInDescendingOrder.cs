using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortInDescendingOrder
{
    class SortInDescendingOrder
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number:");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter third number:");
            int thirdNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("These are numbers {0},{1} and {2} sorted in descending order:", firstNumber, secondNumber, thirdNumber);
            if ((firstNumber > secondNumber) && (firstNumber > thirdNumber))
            {
                if (secondNumber > thirdNumber)
                {
                    Console.WriteLine(firstNumber);
                    Console.WriteLine(secondNumber);
                    Console.WriteLine(thirdNumber);
                }
                else
                {
                    Console.WriteLine(firstNumber);
                    Console.WriteLine(thirdNumber);
                    Console.WriteLine(secondNumber);
                }
            }
            if ((secondNumber > firstNumber) && (secondNumber > thirdNumber))
            {
                if (firstNumber > thirdNumber)
                {
                    Console.WriteLine(secondNumber);
                    Console.WriteLine(firstNumber);
                    Console.WriteLine(thirdNumber);
                }
                else
                {
                    Console.WriteLine(secondNumber);
                    Console.WriteLine(thirdNumber);
                    Console.WriteLine(firstNumber);
                }
            }
            if ((thirdNumber > firstNumber) && (thirdNumber > secondNumber))
            {
                if (firstNumber > secondNumber)
                {
                    Console.WriteLine(thirdNumber);
                    Console.WriteLine(firstNumber);
                    Console.WriteLine(secondNumber);
                }
                else
                {
                    Console.WriteLine(thirdNumber);
                    Console.WriteLine(secondNumber);
                    Console.WriteLine(firstNumber);
                }
            }
        }
    }
}
