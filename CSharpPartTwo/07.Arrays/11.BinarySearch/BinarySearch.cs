using System;
using System.Linq;

namespace _11.BinarySearch
{
    class BinarySearch
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter element value: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Enter value of the element you are searching: ");
            int searchValue = int.Parse(Console.ReadLine());
            int lowValue = 0;
            int highValue = numbers.Length - 1;
            int midValue = lowValue + highValue / 2;
            while (lowValue <= highValue)
            {
                midValue = (lowValue + highValue) / 2;
                if (numbers[midValue] == searchValue)
                {
                    Console.WriteLine("{0} is on position {1}", searchValue, midValue);
                    break;
                }
                else if (numbers[midValue] < searchValue)
                {
                    lowValue = midValue + 1;
                }
                else
                {
                    highValue = midValue - 1;
                }
            }
        }
    }
}
