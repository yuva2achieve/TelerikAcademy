using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumOfNNumbers
{
    class SumOfNNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number:");
            int number = int.Parse(Console.ReadLine());
            int[] numbers = new int[number];
            int i;
            int sumNumbers;
            for (i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Please enter number:");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            sumNumbers = numbers.Sum() + number;
            Console.WriteLine("Sum of entered numbers is:{0}", sumNumbers);
        }
    }
}
