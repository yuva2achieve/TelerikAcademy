using System;
using System.Linq;

namespace _07.SelectionSort
{
    class SelectionSort
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] unsortedArray = new int[n];
            int minValue = 0;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter element value: ");
                unsortedArray[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Unsorted Array: ");
            foreach (var number in unsortedArray)
            {
                Console.Write("{0} ", number);
            }
            for (int i = 0; i < unsortedArray.Length; i++)
            {
                minValue = unsortedArray[i];
                for (int j = i + 1; j < unsortedArray.Length; j++)
                {
                    if (unsortedArray[j] <= unsortedArray[i])
                    {
                        minValue = unsortedArray[j];
                        unsortedArray[j] = unsortedArray[i];
                        unsortedArray[i] = minValue;
                    }
                }
            }
            Console.WriteLine("Sorted Array: ");
            foreach (var number in unsortedArray)
            {
                Console.Write("{0} ", number);
            }
        }
    }
}
