namespace _01.RotateFigure
{
    using System;
    using System.Linq;

    public class Figure
    {
        private double width;
        private double height;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width must be bigger than 0");
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height must be bigger than 0");
                }
            }
        }

        public static Figure RotateFigure(Figure figureToRotate, double figureAngle)
        {
            double rotatedFigureWidth = (Math.Abs(Math.Cos(figureAngle)) * figureToRotate.Width) + 
                (Math.Abs(Math.Sin(figureAngle)) * figureToRotate.Height);
            double rotatedFigureHeight = (Math.Abs(Math.Sin(figureAngle)) * figureToRotate.Width) +
                            (Math.Abs(Math.Cos(figureAngle)) * figureToRotate.Height);
            Figure rotatedFigure = new Figure(rotatedFigureWidth, rotatedFigureHeight);
            return rotatedFigure;
        }
    }
}
