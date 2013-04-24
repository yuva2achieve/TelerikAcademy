using System;
using System.Linq;

namespace _01.Shapes
{
    public class Circle : Shape
    {
        public Circle(double diameter)
        {
            this.Width = diameter / 2;
            this.Height = diameter / 2;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * (this.Height * this.Height);
            return surface;
        }
    }
}
