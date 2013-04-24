using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.GreatestOfFiveVariables
{
    class GreatestOfFiveVariables
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number:");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter third number:");
            int thirdNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter fourth number:");
            int fourthNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter fifth number:");
            int fifthNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("You entered numbers {0},{1},{2},{3} and {4}", firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber);
            Console.WriteLine("Biggest number is:");
            if ((firstNumber > secondNumber) && (firstNumber > thirdNumber) && (firstNumber > fourthNumber) && (firstNumber > fifthNumber))
            {
                Console.WriteLine(firstNumber);
            }
            if ((secondNumber > firstNumber) && (secondNumber > thirdNumber) && (secondNumber > fourthNumber) && (secondNumber > fifthNumber))
            {
                Console.WriteLine(secondNumber);
            }
            if ((thirdNumber > firstNumber) && (thirdNumber > secondNumber) && (thirdNumber > fourthNumber) && (thirdNumber > fifthNumber))
            {
                Console.WriteLine(thirdNumber);
            }
            if ((fourthNumber > firstNumber) && (fourthNumber > secondNumber) && (fourthNumber > thirdNumber) && (fourthNumber > fifthNumber))
            {
                Console.WriteLine(fourthNumber);
            }
            if ((fifthNumber > firstNumber) && (fifthNumber > secondNumber) && (fifthNumber > thirdNumber) && (fifthNumber > fourthNumber))
            {
                Console.WriteLine(fifthNumber);
            }
        }
    }
}
