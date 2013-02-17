using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeBitValue
{
    class ChangeBitValue
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter bit value");
            int v = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter bit position");
            int p = int.Parse(Console.ReadLine());
            int result;
            if (v==1)
            {
                result = n | (1 << p);
            }
            else
            {
                result = n & (~(1 << p));
            }
            Console.WriteLine("The number {0} with bit on position {1} with value {2} is {3}", n, p, v, result);
        }
    }
}
