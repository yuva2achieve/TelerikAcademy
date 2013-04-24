using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PrintNumbersFromOneToN
{
    class PrintNumbersFromOneToN
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n:");
            int n = int.Parse(Console.ReadLine());
            int count = 1;
            while (count <= n)
            {
                Console.WriteLine(count);
                count++;
            }
        }
    }
}
