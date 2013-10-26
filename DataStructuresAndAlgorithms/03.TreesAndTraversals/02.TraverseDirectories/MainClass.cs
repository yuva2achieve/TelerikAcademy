using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02.TraverseDirectories
{
    public class MainClass
    {
        private static readonly List<string> filesFound = new List<string>();

        public static void Main(string[] args)
        {
            string startDirectory = @"C:\Windows";
            TraverseFolders(startDirectory);
            // Check fileNames.txt in debug folder to see all exe files
            StreamWriter sW = new StreamWriter("fileNames.txt");
            using (sW)
            {
                foreach (var filePath in filesFound)
                {
                    sW.WriteLine(Path.GetFileName(filePath));
                }
            }
        }

        static void TraverseFolders(string sDir)
        {
            try
            {
                foreach (var item in Directory.GetFiles(sDir, "*.exe"))
                {
                    filesFound.Add(item);
                }

                foreach (var item in Directory.GetDirectories(sDir))
                {
                    TraverseFolders(item);
                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}
