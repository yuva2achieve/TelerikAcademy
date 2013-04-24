using System;
using System.Linq;

namespace _04.CountNumberInArray
{
    class CountNumberInArray
    {
        static void GetCount(int numValue,int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == numValue)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("There is no such element!");
            }
            else
            {
                Console.WriteLine("Element {0} appears {1} times!", numValue, count);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            int[] arr = { 5, 2, 6, 0, 1, 3, 2, 5, 6, 6, 0 };
            GetCount(number, arr);
        }
    }
}
