using System;
using System.Linq;

namespace _01.MultiplyByFive
{
    class MultiplyByFive
    {
        static void Main(string[] args)
        {
            /* Declares array of 20 elements and fills it with values from 0 to 19*/
            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i * 5;
            }
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
