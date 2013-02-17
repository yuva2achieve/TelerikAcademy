using System;
using System.Linq;
using System.Text;

namespace _06.BinToHex
{
    class BinToHex
    {
        static void Main(string[] args)
        {
            string binaryNum = "001011100001";
            string tmp = "";
            int index = 0;
            StringBuilder numInHex = new StringBuilder();
            while (index < binaryNum.Length)
            {
                tmp = binaryNum.Substring(index, 4);
                switch (tmp)
                {
                    case "0000": numInHex.Append('0');  break;
                    case "0001": numInHex.Append('1');  break;
                    case "0010": numInHex.Append('2');  break;
                    case "0011": numInHex.Append('3');  break;
                    case "0100": numInHex.Append('4');  break;
                    case "0101": numInHex.Append('5');  break;
                    case "0110": numInHex.Append('6');  break;
                    case "0111": numInHex.Append('7');  break;
                    case "1000": numInHex.Append('8');  break;
                    case "1001": numInHex.Append('9');  break;
                    case "1010": numInHex.Append('A');  break;
                    case "1011": numInHex.Append('B');  break;
                    case "1100": numInHex.Append('C');  break;
                    case "1101": numInHex.Append('D');  break;
                    case "1110": numInHex.Append('E');  break;
                    case "1111": numInHex.Append('F'); break;
                }
                index += 4;
            }
            Console.WriteLine(numInHex);
        }
    }
}
