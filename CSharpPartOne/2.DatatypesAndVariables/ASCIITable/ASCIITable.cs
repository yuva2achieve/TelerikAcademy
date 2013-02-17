using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIITable
{
    class ASCIITable
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.ASCII;


            for (byte counter = 0; counter < 128; counter++)
            {
                Console.WriteLine((char)counter);
            }
        }
    }
}
