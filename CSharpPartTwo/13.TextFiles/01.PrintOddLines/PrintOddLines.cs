using System;
using System.Linq;
using System.IO;

namespace _01.PrintOddLines
{
    class PrintOddLines
    {
        static void Main(string[] args)
        {
            Console.Write("Enter path: ");
            string path = Console.ReadLine();
            StreamReader myReader = new StreamReader(path);
            string line = "";
            int counter = 1;
            using (myReader)
            {
                while (myReader.EndOfStream == false)
                {
                    line = myReader.ReadLine();
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                }
            }
        }
    }
}
