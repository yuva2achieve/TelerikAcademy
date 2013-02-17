using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ShowTheSignOfAProduct
{
    class ShowTheSignOfAProduct
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number:");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter third number:");
            int thirdNumber = int.Parse(Console.ReadLine());
            if ((firstNumber > 0) && (secondNumber > 0) && (thirdNumber > 0))
            {
                Console.WriteLine("+");
            }
            else if (((firstNumber < 0) && (secondNumber < 0) && (thirdNumber > 0)))
            {
                Console.WriteLine("+");
            }
            else if (((firstNumber > 0) && (secondNumber < 0) && (thirdNumber < 0)))
            {
                Console.WriteLine("+");
            }
            else if (((firstNumber < 0) && (secondNumber > 0) && (thirdNumber < 0)))
            {
                Console.WriteLine("+");
            }
            else if ((firstNumber < 0) && (secondNumber < 0)&&(thirdNumber < 0))
            {
                Console.WriteLine("-");
            }
            else if (((firstNumber < 0) && (secondNumber > 0) && (thirdNumber > 0)))
            {
                Console.WriteLine("-");
            }
            else if (((firstNumber > 0) && (secondNumber < 0) && (thirdNumber > 0)))
            {
                Console.WriteLine("-");
            }
            else if (((firstNumber > 0) && (secondNumber > 0) && (thirdNumber < 0)))
            {
                Console.WriteLine("-");
            }
            else if (((firstNumber == 0) || (secondNumber == 0) || (thirdNumber == 0)))
            {
                Console.WriteLine("Product is 0");
            }
        }
    }
}
