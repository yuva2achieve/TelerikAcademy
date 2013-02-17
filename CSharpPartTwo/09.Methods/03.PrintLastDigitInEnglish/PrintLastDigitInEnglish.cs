using System;
using System.Linq;

namespace _03.PrintLastDigitInEnglish
{
    class PrintLastDigitInEnglish
    {
        static void PrintLastDigit(int a)
        {
            switch (a)
            {
                case 0: Console.WriteLine("Zero"); break;
                case 1: Console.WriteLine("One"); break;
                case 2: Console.WriteLine("Two"); break;
                case 3: Console.WriteLine("Three"); break;
                case 4: Console.WriteLine("Four"); break;
                case 5: Console.WriteLine("Five"); break;
                case 6: Console.WriteLine("Six"); break;
                case 7: Console.WriteLine("Seven"); break;
                case 8: Console.WriteLine("Eight"); break;
                case 9: Console.WriteLine("Nine"); break;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter integer number: ");
            int number = int.Parse(Console.ReadLine());
            int lastDigit = number % 10;
            PrintLastDigit(lastDigit);
        }
    }
}
