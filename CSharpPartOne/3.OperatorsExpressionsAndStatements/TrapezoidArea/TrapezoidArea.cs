using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrapezoidArea
{
    class TrapezoidArea
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter b:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter h:");
            double h = double.Parse(Console.ReadLine());
            double trapezoidArea = ((a + b) / 2) * h;
            Console.WriteLine("The trapezoid area is: {0}", trapezoidArea);
        }
    }
}
