using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _09.CatalanNumbers
{
    class CatalanNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N:");
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            BigInteger m = 2 * n;
            BigInteger p = n + 1;
            BigInteger nFactorial = 1;
            BigInteger mFactorial = 1;
            BigInteger pFactorial = 1;
            BigInteger catalanNumber;
            for (int i = 1; i <= n; i++)
            {
                nFactorial *= i;
            }
            for (int i = 1; i <= m; i++)
            {
                mFactorial *= i;
            }
            for (int i = 1; i <= p; i++)
            {
                pFactorial *= i;
            }
            catalanNumber = mFactorial / (pFactorial * nFactorial);
            Console.WriteLine(catalanNumber);
        }
    }
}
