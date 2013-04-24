using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIfNumberIsPrime
{
    class CheckIfNumberIsPrime
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number: ");
            int givenNumber = int.Parse(Console.ReadLine());
            int maxDivider = (int)Math.Sqrt(givenNumber);
            bool isPrime = true;
            for (int divider = 2; divider <= maxDivider; divider++)
            {
                if (givenNumber % divider == 0)
                {
                    isPrime = false;
                }
            }
            Console.WriteLine(isPrime);
        }
    }
}
