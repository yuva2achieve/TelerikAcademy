using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeBitsPWithBitsQ
{
    class ExchangeBitsPWithBitsQ
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter P:");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Q:");
            int q = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter K:");
            int k = int.Parse(Console.ReadLine());
            int bitP;
            int[] bitValueP = new int[32];
            int bitQ;
            int[] bitValueQ = new int[32];
            int i;
            int l = p;
            int j = p + (k - 1); 
            int x;
            int y = q;
            int z = q + (k - 1);
            Console.WriteLine("Values before the exchange:");
            for (i=p;i<=p+(k-1); i++)
            {
                bitP = number & (1 << i);
                bitValueP[i] = bitP >> i;
                Console.WriteLine("Value of bit on position {0} is {1}", i,bitValueP[i]);
            }
            for (x = q; x <= q+(k-1); x++)
            {
                bitQ = number & (1 << x);
                bitValueQ[x] = bitQ >> x;
                Console.WriteLine("Value of bit on position {0} is {1}", x, bitValueQ[x]);
            }
            Console.WriteLine("Values after the exchange:");
            do
            {
                bitValueP[l] = bitValueQ[y];
                Console.WriteLine("Bit on position {0} is {1}", l, bitValueP[l]);
                l++;
                y++;
            } while ((l <= j) && (y <= z));
        }
    }
}