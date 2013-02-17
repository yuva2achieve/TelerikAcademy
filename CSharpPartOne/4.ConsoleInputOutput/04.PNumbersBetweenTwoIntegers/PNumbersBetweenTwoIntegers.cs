using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PNumbersBetweenTwoIntegers
{
    class PNumbersBetweenTwoIntegers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter first number:");
            int firstInt = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter second number:");
            int secondInt = int.Parse(Console.ReadLine());
            int numCount = 0;
            if (firstInt>secondInt)
            {
                for (int i = secondInt; i <= firstInt; i++)
                {
                    if (i % 5 == 0)
                    {
                        numCount++;
                    }
                }
            }
            else
            {
                for (int x = firstInt; x <= secondInt; x++)
                {
                    if (x % 5 == 0)
                    {
                        numCount++; 
                    }
                }
            }
            Console.WriteLine("There are {0} numbers between {1} and {2} that can be divided by five without remainder.", numCount, firstInt, secondInt);
        }
    }
}
