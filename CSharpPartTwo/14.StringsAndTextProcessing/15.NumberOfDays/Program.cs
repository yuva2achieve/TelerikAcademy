using System;
using System.Globalization;
using System.Linq;

namespace _15.NumberOfDays
{
    class Program
    {
        static void Main(string[] args)
        {
            string date1 = "27.02.2006";
            string date2 = "03.03.2006";
            DateTime firstDate = DateTime.ParseExact(date1,"dd.MM.yyyy",CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(date2,"dd.MM.yyyy",CultureInfo.InvariantCulture);
            TimeSpan result = new TimeSpan();
            if (firstDate.CompareTo(secondDate) < 0)
            {
                result = secondDate - firstDate;
                Console.WriteLine(result.TotalDays);
            }
            else if (firstDate.CompareTo(secondDate) > 0)
            {
                result = firstDate - secondDate;
                Console.WriteLine(result.TotalDays);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
