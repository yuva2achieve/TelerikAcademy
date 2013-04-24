using System;
using System.Linq;

namespace _05.CalculateWorkdays
{
    class CalculateWorkdays
    {
        static void Main(string[] args)
        {
            DateTime current = DateTime.Today;
            DateTime next = DateTime.Today.AddMonths(1);
            int[] workDays = { 20, 26, 3, 9 };
            int workDaysCount = 0;
            int counter = 0;
            while (current != next)
            {
                if ((current.DayOfWeek != DayOfWeek.Saturday) && (current.DayOfWeek != DayOfWeek.Sunday))
                {
                    workDaysCount++;
                }
                if (counter < workDays.Length)
                {
                    if (current.Day == workDays[counter])
                    {
                        workDaysCount++;
                        counter++;
                    }
                }
                current = current.AddDays(1);
            }
            Console.WriteLine(workDaysCount);
        }
    }
}
