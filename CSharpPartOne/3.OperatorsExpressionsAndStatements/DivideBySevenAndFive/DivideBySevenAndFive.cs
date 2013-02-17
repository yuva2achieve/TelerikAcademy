using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideBySevenAndFive
{
    class DivideBySevenAndFive
    {
        static void Main(string[] args)
        {
            int givenNumber = 70;
            bool divideByFiveAndSeven = (givenNumber % 5 == 0) && (givenNumber % 7 == 0);
            Console.WriteLine("Given number can be dived by 5 and 7: {0}", divideByFiveAndSeven);
        }
    }
}
