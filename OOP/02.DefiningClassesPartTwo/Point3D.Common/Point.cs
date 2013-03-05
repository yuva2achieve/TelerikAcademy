using System;
using System.Linq;
using System.Text;

namespace Point3D.Common
{
    public struct Point
    {
        // Fields
        private double x;
        private double y;
        private double z;
        private static readonly Point coordinateSystemStart = new Point(0d, 0d, 0d);

        // Constructor
        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        // Properties
        public double X
        {
            get { return this.x; }
            set
            {
                try
                {
                    this.x = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public double Y
        {
            get { return this.y; }
            set
            {
                try
                {
                    this.y = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public double Z
        {
            get { return this.z; }
            set
            {
                try
                {
                    this.z = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static Point CoordinateSystemStart
        {
            get { return coordinateSystemStart; }
        }
        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendFormat("X: {0} \n", this.x);
            myBuilder.AppendFormat("Y: {0} \n", this.y);
            myBuilder.AppendFormat("Z: {0} ", this.z);
            return myBuilder.ToString();
        }
    }
}
