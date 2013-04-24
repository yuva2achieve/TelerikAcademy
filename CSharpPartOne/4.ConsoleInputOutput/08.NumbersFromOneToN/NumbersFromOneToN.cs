using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.NumbersFromOneToN
{
    class NumbersFromOneToN
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("These are all numbers from 1 to {0}", n);
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
