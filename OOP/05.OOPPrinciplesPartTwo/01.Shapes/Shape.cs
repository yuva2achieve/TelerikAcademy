using System;
using System.Linq;

namespace _01.Shapes
{
    public abstract class Shape
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public abstract double CalculateSurface();
    }
}
