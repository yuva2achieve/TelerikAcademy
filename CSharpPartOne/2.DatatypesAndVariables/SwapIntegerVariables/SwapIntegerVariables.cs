using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapIntegerVariables
{
    class SwapIntegerVariables
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            int c = 0;
            c = a;
            a = b;
            b = c;
            Console.WriteLine("{0},{1}", a, b);
        }
    }
}
