using System;
using System.Linq;

namespace _01.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalculateSurface()
        {
            double surface = (this.Width * this.Height) / 2;
            return surface;
        }
    }
}
