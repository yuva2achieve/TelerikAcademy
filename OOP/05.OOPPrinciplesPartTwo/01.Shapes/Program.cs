using System;
using System.Linq;

namespace _01.Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle testCircle = new Circle(5);
            Triangle testTriangle = new Triangle(12.5, 6.4);
            Rectangle testRectangle = new Rectangle(10.2, 3.5);
            Console.WriteLine(testTriangle.CalculateSurface());
            Console.WriteLine(testRectangle.CalculateSurface());
            Console.WriteLine(testCircle.CalculateSurface());
        }
    }
}
