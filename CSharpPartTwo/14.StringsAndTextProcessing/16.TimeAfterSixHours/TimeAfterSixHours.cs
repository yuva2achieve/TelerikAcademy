using System;
using System.Linq;
using System.Threading;
using System.Globalization;

namespace _16.TimeAfterSixHours
{
    class TimeAfterSixHours
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
            string input = "31.01.2013 23:25:15";
            DateTime firstDate = DateTime.ParseExact(input, "dd.MM.yyyy H:mm:ss", CultureInfo.CurrentCulture);
            DateTime result = firstDate.AddHours(6);
            result.AddMinutes(30);
            Console.WriteLine("{0:dd.MM.yyyy H:MM:ss}",result);
            Console.WriteLine(DateTimeFormatInfo.CurrentInfo.GetDayName(result.DayOfWeek));
        }
    }
}
