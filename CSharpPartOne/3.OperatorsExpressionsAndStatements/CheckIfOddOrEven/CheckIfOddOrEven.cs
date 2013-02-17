using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIfOddOrEven
{
    class CheckIfOddOrEven
    {
        static void Main(string[] args)
        {
            int givenNumber = 12;
            if (givenNumber%2==0)
            {
                Console.WriteLine("The number {0} is even", givenNumber);
            }
            else
            {
                Console.WriteLine("The number {0} is odd", givenNumber);
            }
        }
    }
}
