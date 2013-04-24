using System;
using System.Linq;
using Point3D.Common;

namespace Point3DTest
{
    class Point3DTest
    {
        static void Main(string[] args)
        {
            Path testPath = new Path();
            testPath.PointSequence.Add(new Point(23,4,10));
            var testStorage = PathStorage.LoadPath(@"../../input.txt");
            foreach (var item in testStorage)
            {
                PathStorage.SavePath(item);
            }
        }
    }
}
