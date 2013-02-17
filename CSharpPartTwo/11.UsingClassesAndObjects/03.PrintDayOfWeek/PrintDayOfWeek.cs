using System;
using System.Linq;

namespace _03.PrintDayOfWeek
{
    class PrintDayOfWeek
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Today;
            Console.WriteLine(today.DayOfWeek);
            
        }
    }
}
