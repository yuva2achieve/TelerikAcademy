using System;
using System.Globalization;
using System.Linq;

namespace _03.DefineException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter value between in interval [0,20]: ");
            try
            {
                int inputValue = int.Parse(Console.ReadLine());
                if (inputValue < 0 || inputValue > 20)
	            {
		            throw new InvalidRangeException<int>("Number must be in interval [",0,20);
	            }
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message + e.Min + "," + e.Max + "]");
            }
            Console.Write("Enter date between 01.01.1980 and 31.12.2013:");
            try
            {
                DateTime inputDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DateTime minDate = DateTime.ParseExact("01.01.1980", "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DateTime maxDate = DateTime.ParseExact("31.12.2013", "dd.MM.yyyy", CultureInfo.InvariantCulture);
                if (inputDate < minDate || inputDate > maxDate)
                {
                    throw new InvalidRangeException<DateTime>("Date must be after: ",minDate,maxDate);
                }
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message + e.Min + " and before: " + e.Max);
            }
        }
    }
}
