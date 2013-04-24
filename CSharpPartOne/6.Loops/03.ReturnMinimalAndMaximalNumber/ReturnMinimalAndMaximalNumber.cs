using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ReturnMinimalAndMaximalNumber
{
    class ReturnMinimalAndMaximalNumber
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            Console.WriteLine("Enter n:");
            int n = int.Parse(Console.ReadLine());
            int count = 1;
            int number;
            while (count <= n)
            {
                number = int.Parse(Console.ReadLine());
                if (number > max)
                {
                    max = number;
                }
                else if (number < min)
                {
                    min = number;   
                }
                count++;
            }
            Console.WriteLine("Minimal number is {0}", min);
            Console.WriteLine("Maximal number is {0}", max);
        }
    }
}
