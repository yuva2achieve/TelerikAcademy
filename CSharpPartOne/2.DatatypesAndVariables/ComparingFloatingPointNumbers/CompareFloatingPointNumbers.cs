using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingFloatingPointNumbers
{
    class CompareFloatingPointNumbers
    {
        static void Main(string[] args)
        {
            float firstNumber = 5.000000001f;
            float secondNumber = 5.000000003f;
            bool compareNumbers = firstNumber == secondNumber;
            Console.WriteLine("First number is equal to second number: {0} ", compareNumbers);
        }
    }
}
