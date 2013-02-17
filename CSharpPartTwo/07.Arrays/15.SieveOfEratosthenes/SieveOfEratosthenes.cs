using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.SieveOfEratosthenes
{
    class SieveOfEratosthenes
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[10000001];
            int stop = (int)Math.Sqrt(10000000);
            for (int i = 2; i < stop; i++)
            {
                for (int j = i * 2; j < myArray.Length; j+=i)
                {
                    myArray[j] = 1;
                }
            }
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == 0)
                {
                    Console.Write("{0} ", i);
                }
            }
        }
    }
}
