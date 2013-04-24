using System;
using System.Linq;

namespace _02.ReadNumber
{
    class ReadNumber
    {
        static void Main(string[] args)
        {
            int numValue;
            int startValue = 0;
            int endValue = 100;
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    numValue = ReadNumberInGivenRange(startValue, endValue);
                    startValue = numValue;
                    Console.WriteLine(numValue);
                }
            }
            catch (ArgumentOutOfRangeException myException)
            {
                Console.WriteLine(myException.Message);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number is too big");
            }
            catch (FormatException)
            {
                Console.WriteLine("Number must be integer");
            }
        }

        static int ReadNumberInGivenRange(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());
            if ((number < start) || (number > end))
            {
                throw new ArgumentOutOfRangeException("Number is outside of valid range ");
            }
            return number;
        }
    }
}
