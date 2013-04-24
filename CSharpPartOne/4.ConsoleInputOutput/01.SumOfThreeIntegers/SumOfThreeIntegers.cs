using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumOfThreeIntegers
{
    class SumOfThreeIntegers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter first integer:");
            int firstInt = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter second integer:");
            int secondInt = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter third integer:");
            int thirdInt = int.Parse(Console.ReadLine());
            int sum = firstInt + secondInt + thirdInt;
            Console.WriteLine("Sum of the integers is: {0}", sum);
        }
    }
}
