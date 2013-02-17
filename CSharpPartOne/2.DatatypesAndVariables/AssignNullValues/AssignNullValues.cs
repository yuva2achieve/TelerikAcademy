using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignNullValues
{
    class AssignNullValues
    {
        static void Main(string[] args)
        {
            int firstInt = 0;
            double firstDouble = 0.0d;
            Console.WriteLine("{0},{1}", firstInt, firstDouble);
            Console.WriteLine(firstInt + 5);
            Console.WriteLine(firstDouble + 5.1d);
            Console.WriteLine(firstInt + null);
            Console.WriteLine(firstDouble + null);
        }
    }
}
