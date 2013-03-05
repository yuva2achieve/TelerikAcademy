using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point3D.Common
{
    public class Path
    {
        // Fields
        private readonly List<Point> pointSequence = new List<Point>();
        // Properties
        public List<Point> PointSequence
        {
            get { return this.pointSequence; }
        }
        // Methods
        public void Add(Point a)
        {
            pointSequence.Add(a);
        }
        public void Clear()
        {
            this.pointSequence.Clear();
        }
        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            for (int i = 0; i < pointSequence.Count; i++)
            {
                myBuilder.Append(pointSequence[i]);
                myBuilder.AppendLine();
            }
            return myBuilder.ToString();
        }
    }
}