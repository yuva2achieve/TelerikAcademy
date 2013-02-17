using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.FibonacciSequence
{
    class FibonacciSequence
    {
        static void Main(string[] args)
        {
            decimal a = 0m;
            decimal b = 1m;
            decimal c = 1m;
            Console.WriteLine("These are first 100 members of the Fibonacci sequence:");
            for (int i = 0; i <= 100; i++)
            {
                c = a + b;
                a = b;
                b = c;
                Console.WriteLine(c);
            }
        }
    }
}
