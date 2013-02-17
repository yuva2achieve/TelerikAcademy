using System;
using System.Linq;

namespace _10.FormatNumber
{
    class FormatNumber
    {
        static void Main(string[] args)
        {
            int inputNum = 15042;
            Console.WriteLine("{0,15}",inputNum);
            Console.WriteLine("{0,15:X}",inputNum);
            Console.WriteLine("{0,15:P}",inputNum);
            Console.WriteLine("{0,15:E}", inputNum);
        }
    }
}
