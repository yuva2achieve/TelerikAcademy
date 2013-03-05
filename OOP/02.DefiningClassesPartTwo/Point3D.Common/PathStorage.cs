using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Point3D.Common
{
    public static class PathStorage
    {
        public static void SavePath(Path path)
        {
            StreamWriter myWriter = new StreamWriter(@"../../output.txt");
            using (myWriter)
            {
                foreach (var item in path.PointSequence)
                {
                    myWriter.WriteLine(item);
                }
            }
        }
        public static List<Path> LoadPath(string inputFileLocation)
        {
            List<Path> storage = new List<Path>();
            StreamReader myReader = new StreamReader(inputFileLocation);
            using (myReader)
            {
                Path temp = new Path();
                while (myReader.EndOfStream == false)
                {
                    string line = myReader.ReadLine();
                    if (line != "end")
                    {
                        Point tempPoint = new Point();
                        string[] splitLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        tempPoint.X = double.Parse(splitLine[0]);
                        tempPoint.Y = double.Parse(splitLine[1]);
                        tempPoint.Z = double.Parse(splitLine[2]);
                        temp.Add(tempPoint);
                    }
                    else
                    {
                        storage.Add(temp);
                        temp = new Path();
                    }
                }
            }
            return storage;
        }
    }
}
