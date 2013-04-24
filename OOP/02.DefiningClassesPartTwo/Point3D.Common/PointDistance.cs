using System;
using System.Linq;

namespace Point3D.Common
{
    public static class PointDistance
    {
        public static double CalculateDistance(Point a, Point b)
        {
            // Calculating Euclidean distance
            double result = Math.Sqrt(((a.X - b.X) * (a.X - b.X)) + ((a.Y - b.Y) * (a.Y - b.Y)) + ((a.Z - b.Z) * (a.Z - b.Z)));
            return result;
        }
    }
}
