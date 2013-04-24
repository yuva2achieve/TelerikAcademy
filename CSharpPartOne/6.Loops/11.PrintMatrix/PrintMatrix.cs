using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PrintMatrix
{
    class PrintMatrix
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N:");
            byte n = byte.Parse(Console.ReadLine());
            int count = 1;
            for (int rows = 1; rows <= n; rows++)
            {
                count = rows;
                for (int columns = 1; columns <= n; columns++)
                {
                    Console.Write("{0} \t",count);
                    count++;
                }
                Console.WriteLine();
            }
        }
    }
}
