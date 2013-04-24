using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NumbersNotDivisibleByThreeAndSeven
{
    class NumbersNotDivisibleByThreeAndSeven
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n:");
            int n = int.Parse(Console.ReadLine());
            int count = 1;
            while (count <= n)
            {
                if ((count % 3 != 0) && (count % 7 != 0))
                {
                    Console.WriteLine(count);
                }
                count++; 
            }
        }
    }
}
