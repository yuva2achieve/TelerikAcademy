using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.TrailingZeros
{
    class TrailingZeros
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N:");
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            int power = 1;
            while ((n/power) > 0)
            {
                power *= 5;
                count += n / power;
            }
            Console.WriteLine("Number of trailing zeros in {0}! is {1}", n, count);
        }
    }
}
