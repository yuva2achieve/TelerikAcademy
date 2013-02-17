using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DivideNFactorielByKFactoriel
{
    class DivideNFactorialByKFactorial
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N:");
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter K:");
            long k = long.Parse(Console.ReadLine());
            long nFactorial = 1;
            long kFactorial = 1;
            long division;
            while (n > 0)
            {
                nFactorial *= n;
                n--;
            }
            while (k > 0)
            {
                kFactorial *= k;
                k--;
            }
            division = nFactorial / kFactorial;
            Console.WriteLine(division);
        }
    }
}
