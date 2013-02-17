using System;
using System.Linq;

namespace _09.ConvertToUnicode
{
    class ConvertToUnicode
    {
        static void Main(string[] args)
        {
            string input = "Hi!";
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write("\\u{0:X4}", (int)input[i]);
            }
        }
    }
}
