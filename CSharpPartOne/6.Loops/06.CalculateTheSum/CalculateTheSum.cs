using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _06.CalculateTheSum
{
    class CalculateTheSum
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N:");
            double n = double.Parse(Console.ReadLine());
            Console.Write("Enter X:");
            double x = double.Parse(Console.ReadLine());
            double pow = 1d;
            double sum = 1d;
            double factorial = 1d;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
                pow = Math.Pow(x,i);
                sum += factorial / pow;
            }
            Console.WriteLine(sum);
        }
    }
}
