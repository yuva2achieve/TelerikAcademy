using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SumOfNumbers
{
    class SumOfNumbers
    {
        static void Main(string[] args)
        {
            decimal sum = 1m;
            decimal newSum = 1m;
            decimal divisor = 2m;
            decimal difference;
            do
            {
                sum = newSum;
                if (divisor % 2 == 0)
                {
                    newSum += 1 / divisor;
                }
                else
                {
                    newSum -= 1 / divisor;
                }
                difference = Math.Abs(newSum - sum);
                divisor++;
            } while (difference >= 0.001m);
            Console.WriteLine("{0:0.000}", sum);
        }
    }
}
