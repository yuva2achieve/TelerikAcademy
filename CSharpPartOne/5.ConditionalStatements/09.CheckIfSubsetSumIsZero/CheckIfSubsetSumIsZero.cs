using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CheckIfSubsetSumIsZero
{
    class CheckIfSubsetSumIsZero
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter third number:");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter fourth number:");
            int d = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter fifth number:");
            int e = int.Parse(Console.ReadLine());
            if (a == 0)
            {
                Console.WriteLine("{0} = 0", a);
            }
            else if (b == 0)
            {
                Console.WriteLine("{0} = 0", b);
            }
            else if (c == 0)
            {
                Console.WriteLine("{0} = 0", c);
            }
            else if (d == 0)
            {
                Console.WriteLine("{0} = 0", d);
            }
            else if (e == 0)
            {
                Console.WriteLine("{0} = 0", b);
            }
            else if (a + b == 0)
            {
                Console.WriteLine("{0} + {1} = 0", a, b);
            }
            else if (a + c == 0)
            {
                Console.WriteLine("{0} + {1} = 0", a, c);
            }
            else if (a + d == 0)
            {
                Console.WriteLine("{0} + {1} = 0", a, d);
            }
            else if (a + e == 0)
            {
                Console.WriteLine("{0} + {1} = 0", a, e);
            }
            else if (b + c == 0)
            {
                Console.WriteLine("{0} + {1} = 0", b, c);
            }
            else if (b + d == 0)
            {
                Console.WriteLine("{0} + {1} = 0", b, d);
            }
            else if (b + e == 0)
            {
                Console.WriteLine("{0} + {1} = 0", b, e);
            }
            else if (c + d == 0)
            {
                Console.WriteLine("{0} + {1} = 0", c, d);
            }
            else if (c + e == 0)
            {
                Console.WriteLine("{0} + {1} = 0", c, e);
            }
            else if (d + e == 0)
            {
                Console.WriteLine("{0} + {1} = 0", d, e);
            }
            else if (a + b + c == 0)
            {
                Console.WriteLine("{0} + {1} + {2} = 0", a, b, c);
            }
            else if (a + b + d == 0)
            {
                Console.WriteLine("{0} + {1} + {2} = 0", a, b, d);
            }
            else if (a + b + e == 0)
            {
                Console.WriteLine("{0} + {1} + {2} = 0", a, b, e);
            }
            else if (a + c + d == 0)
            {
                Console.WriteLine("{0} + {1} + {2} = 0", a, c, d);
            }
            else if (a + c + e == 0)
            {
                Console.WriteLine("{0} + {1} + {2} = 0", a, c, e);
            }
            else if (a + d + e == 0)
            {
                Console.WriteLine("{0} + {1} + {2} = 0", a, d, e);
            }
            else if (b + c + d == 0)
            {
                Console.WriteLine("{0} + {1} + {2} = 0", b, c, d);
            }
            else if (b + c + e == 0)
            {
                Console.WriteLine("{0} + {1} + {2} = 0", b, c, e);
            }
            else if (b + d + e == 0)
            {
                Console.WriteLine("{0} + {1} + {2} = 0", b, d, e);
            }
            else if (c + d + e == 0)
            { 
                Console.WriteLine("{0} + {1} + {2} = 0", c, d, e);
            }
            else if (a + b + c + d == 0)
            {
                Console.WriteLine("{0} + {1} + {2} +{3} = 0", a, b, c, d);
            }
            else if (a + c + d + e == 0)
            {
                Console.WriteLine("{0} + {1} + {2} +{3} = 0", a, c, d, e);
            }
            else if (a + d + e + b == 0)
            {
                Console.WriteLine("{0} + {1} + {2} +{3} = 0", a, d, e, b);
            }
            else if (a + e + b + c == 0)
            {
                Console.WriteLine("{0} + {1} + {2} +{3} = 0", a, e, b, c);
            }
            else if (b + c + d + e == 0)
            {
                Console.WriteLine("{0} + {1} + {2} +{3} = 0", b, c, d, e);
            }
            else if (a + b + c + d + e == 0)
            {
                Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", a, b, c, d, e);
            }
        }
    }
}
