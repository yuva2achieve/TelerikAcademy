using System;
using System.Linq;

namespace _01.CheckIfLeapYear
{
    class CheckIfLeapYear
    {
        static void Main(string[] args)
        {
            short year = EnterYear();
            CheckIfLeap(year);
        }
  
        private static void CheckIfLeap(short year)
        {
            bool checkIfLeap = DateTime.IsLeapYear(year);
            Console.WriteLine("Is {0} leap year ?: {1}", year, checkIfLeap);
        }
  
        static short EnterYear()
        {
            Console.Write("Enter year: ");
            short year = short.Parse(Console.ReadLine());
            return year;
        }
    }
}
