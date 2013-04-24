using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace _05.FactorialMultiplicationAndDivision
{
    class FactorialMultiplicationAndDivision
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N:");
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            Console.WriteLine("Enter K:");
            BigInteger k = BigInteger.Parse(Console.ReadLine());
            BigInteger m = k - n;
            BigInteger mFactorial = 1;
            BigInteger nFactorial = 1;
            BigInteger kFactorial = 1;
            BigInteger result = 0;
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
            while (m > 0)
            {
                mFactorial *= m;
                m--;
            }
            result = ((nFactorial * kFactorial) / (mFactorial));
            Console.WriteLine(result);
        }
    } 
}
