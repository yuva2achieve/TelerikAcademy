using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PerimeterAndAreaOfCircle
{
    class PerimeterAndAreaOfCircle
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter radius:");
            double r = double.Parse(Console.ReadLine());
            double perimeter = 2 * Math.PI * r;
            double area = Math.PI * (r * r);
            Console.WriteLine("Perimeter of the circle is: {0}", perimeter);
            Console.WriteLine("Area of the circle is: {0}", area);
        }
    }
}
