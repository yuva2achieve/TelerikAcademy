using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.HexToBin
{
    class HexToBin
    {
        static void Main(string[] args)
        {
            string hexNumber = "2E1";
            var binNumberDigits = new List<string>();
            string tempVariable = "";
            ConvertHexToBin(hexNumber, binNumberDigits, tempVariable);
            foreach (var item in binNumberDigits)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
  
        static void ConvertHexToBin(string hexNumber, List<string> binNumberDigits, string tempVariable)
        {
            foreach (var item in hexNumber)
            {
                switch (item)
                {
                    case '0': tempVariable = " 0000"; break;
                    case '1': tempVariable = " 0001"; break;
                    case '2': tempVariable = " 0010"; break;
                    case '3': tempVariable = " 0011"; break;
                    case '4': tempVariable = " 0100"; break;
                    case '5': tempVariable = " 0101"; break;
                    case '6': tempVariable = " 0110"; break;
                    case '7': tempVariable = " 0111"; break;
                    case '8': tempVariable = " 1000"; break;
                    case '9': tempVariable = " 1001"; break;
                    case 'A': tempVariable = " 1010"; break;
                    case 'B': tempVariable = " 1011"; break;
                    case 'C': tempVariable = " 1100"; break;
                    case 'D': tempVariable = " 1101"; break;
                    case 'E': tempVariable = " 1110"; break;
                    case 'F': tempVariable = " 1111"; break;
                }
                binNumberDigits.Add(tempVariable);
            }
        }
    }
}
