using System;
using System.Linq;

namespace _02.CheckIfPointIsInTriangle
{
    public class CheckIfPointIsInTriangle
    {
        static void Main()
        {
            string pointA = "(5,5)";
            string pointB = "(12,5)";
            string pointC = "(6,10)";
            string pointP = "(7,8)"; // in the triangle
            //string pointP = "(7,5)"; // over one side - in the triangle
            //string pointP = "(7,8)"; // out of the triangle

            Point A = new Point();
            string[] buffer = pointA.Split(new char[] { '(', ')', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            A.X = double.Parse(buffer[0]);
            A.Y = double.Parse(buffer[1]);

            Point B = new Point();
            buffer = pointB.Split(new char[] { '(', ')', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            B.X = double.Parse(buffer[0]);
            B.Y = double.Parse(buffer[1]);

            Point C = new Point();
            buffer = pointC.Split(new char[] { '(', ')', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            C.X = double.Parse(buffer[0]);
            C.Y = double.Parse(buffer[1]);

            Point P = new Point();
            buffer = pointP.Split(new char[] { '(', ')', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            P.X = double.Parse(buffer[0]);
            P.Y = double.Parse(buffer[1]);

            double triangleArea = CalcArea(A, B, C);
            double firstTriangleArea = CalcArea(A, B, P);
            double secondTriangleArea = CalcArea(A, C, P);
            double thirdTriangleArea = CalcArea(C, B, P);

            if (triangleArea == firstTriangleArea + secondTriangleArea + thirdTriangleArea)
            {
                Console.WriteLine("Point P{0} is in triangle.", P.ToString());
            }
            else
            {
                Console.WriteLine("Point P{0} is OUT of triangle.", P.ToString());
            }
        }

        static double CalcArea(Point p1, Point p2, Point p3)
        {
            double p1p2 = p1.CalcDistance(p2);
            double p2p3 = p2.CalcDistance(p3);
            double p3p1 = p3.CalcDistance(p1);
            double s = (p1p2 + p2p3 + +p3p1) / 2;

            double area = Math.Sqrt(s * (s - p1p2) * (s - p2p3) * (s - p3p1));
            return area;
        }
    }
}