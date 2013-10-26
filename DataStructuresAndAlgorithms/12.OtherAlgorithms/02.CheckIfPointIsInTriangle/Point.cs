using System;
using System.Linq;

namespace _02.CheckIfPointIsInTriangle
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double CalcDistance(Point toPoint)
        {
            double distance;
            double dx = (this.X - toPoint.X);
            double dy = (this.Y - toPoint.Y);
            distance = Math.Sqrt(dx * dx + dy * dy);

            return distance;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.X, this.Y);
        }
    }
}