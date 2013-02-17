using System;
using System.Linq;

namespace _02.PrintBiggestOfThreeIntegers
{
    class PrintBiggestOfThreeIntegers
    {
        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter integer: ");
            int firstInteger = int.Parse(Console.ReadLine());
            Console.Write("Enter integer: ");
            int secondInteger = int.Parse(Console.ReadLine());
            Console.Write("Enter integer: ");
            int thirdInteger = int.Parse(Console.ReadLine());
            int biggestInteger = GetMax(firstInteger, secondInteger);
            biggestInteger = GetMax(biggestInteger, thirdInteger);
            Console.WriteLine(biggestInteger); 
        }
    }
}
