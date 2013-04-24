using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FibonacciSequenceSum
{
    class FibonacciSequenceSum
    {
        static void Main(string[] args)
        {
            decimal a = 0m;
            decimal b = 1m;
            decimal c = 1m;
            decimal sum = 1m;
            Console.Write("Enter N:");
            decimal n = decimal.Parse(Console.ReadLine());
            for (int i = 1; i <= n - 2; i++)
            {
                c = a + b;
                a = b;
                b = c;
                sum += c;
            }
            Console.WriteLine(sum);
        }
    }
}
