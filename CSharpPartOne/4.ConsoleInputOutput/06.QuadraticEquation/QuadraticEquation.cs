using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter b:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter c:");
            double c = double.Parse(Console.ReadLine());
            double d = ((b * b) - (4 * a * c));
            double x1;
            double x2;
            if (d>0)
            {
                x1 = ((-b + Math.Sqrt(d)) / (2 * a));
                x2 = ((-b - Math.Sqrt(d)) / (2 * a));
                Console.WriteLine("X1 = {0};X2 = {1}", x1, x2);
            }
            if (d==0)
            {
                x1 = x2 = ((-b) / (2 * a));
                Console.WriteLine("X1 = X2 = {0}", x1);
            }
            if (d<0)
            {
                Console.WriteLine("There are no real roots!");
            }
        }
    }
}
