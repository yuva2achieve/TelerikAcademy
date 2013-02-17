using System;
using System.Linq;

namespace _04.CalculateSurfaceOfTriangle
{
    class CalculateSurfaceOfTriangle
    {
        static void Main(string[] args)
        {
            double surface = GetTriangleSurface(5.3, 4.5);
            Console.WriteLine(surface);
            surface = GetTriangleSurface(4.0, 5.5, 7.3);
            Console.WriteLine(surface);
            surface = GetTriangleSurface(6.2, 4.1, 45);
            Console.WriteLine(surface);
        }

        static double GetTriangleSurface(double side, double altitude)
        {
            double result = (side + altitude) / 2;
            return result;
        }

        static double GetTriangleSurface(double a, double b, double c)
        {
            double result = 0;
            double p = (a + b + c) / 2;
            result = Math.Sqrt(p*((p - a)*(p - b) *(p - c)));
            return result;
        }

        static double GetTriangleSurface(double a, double b, int angleInRadians)
        {
            double result = 0;
            result = (a * b * Math.Sin(angleInRadians)) / 2;
            return result;
        }
    }
}
