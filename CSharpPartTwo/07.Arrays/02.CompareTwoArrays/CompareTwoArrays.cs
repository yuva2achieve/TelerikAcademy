using System;
using System.Linq;

namespace _02.CompareTwoArrays
{
    class CompareTwoArrays
    {
        static void Main(string[] args)
        {
            decimal[] firstArray = new decimal[5];
            decimal[] secondArray = new decimal[5];
            Console.WriteLine("Enter elements of first array");
            for (int i = 0; i < firstArray.Length; i++)
            {
                firstArray[i] = decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter elements of second array");
            for (int i = 0; i < firstArray.Length; i++)
            {
                secondArray[i] = decimal.Parse(Console.ReadLine());
            }
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] > secondArray[i])
                {
                    Console.WriteLine("{0} is bigger than {1}", firstArray[i], secondArray[i]);
                }
                if (firstArray[i] < secondArray[i])
                {
                    Console.WriteLine("{0} is smaller than {1}", firstArray[i], secondArray[i]);
                }
                if (firstArray[i] == secondArray[i])
                {
                    Console.WriteLine("{0} is equal to {1}", firstArray[i], secondArray[i]);
                }
            }
        }
    }
}
