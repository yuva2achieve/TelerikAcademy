using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIfThirdDigitIsSeven
{
    class CheckIfThirdDigitIsSeven
    {
        static void Main(string[] args)
        {
            int givenNumber = 17722;
            int thirdDigit = (givenNumber / 100) % 10;
            if (thirdDigit==7)
            {
                Console.WriteLine("Third digit(right-to-left) is seven");
            }
            else
            {
                Console.WriteLine("Third digit(right-to-left) is: {0}", thirdDigit);
            }
        }
    }
}
