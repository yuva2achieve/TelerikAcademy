using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeBits
{
    class ExchangeBits
    {
        static void Main(string[] args)
        {
            uint n = 155;
            uint bit3AndMask = n & (1 << 3);
            uint bit4AndMask = n & (1 << 4);
            uint bit5AndMask = n & (1 << 5);
            uint bit3Value = bit3AndMask >> 3;
            uint bit4Value = bit4AndMask >> 4;
            uint bit5Value = bit5AndMask >> 5;
            Console.WriteLine("Bit values before the exchange are: {0},{1} and {2}", bit3Value, bit4Value, bit5Value);
            uint bit24AndMask = n & (1 << 24);
            uint bit25AndMask = n & (1 << 25);
            uint bit26AndMask = n & (1 << 26);
            uint bit24Value = bit24AndMask >> 24;
            uint bit25Value = bit25AndMask >> 25;
            uint bit26Value = bit26AndMask >> 26;
            bit3Value = bit24Value;
            bit4Value = bit25Value;
            bit5Value = bit26Value;
            Console.WriteLine("Bit values after the exchange are: {0},{1} and {2}", bit3Value, bit4Value, bit5Value);
        }
    }
}
