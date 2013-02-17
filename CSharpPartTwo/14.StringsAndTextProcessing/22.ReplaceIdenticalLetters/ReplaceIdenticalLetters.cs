using System;
using System.Linq;
using System.Text;

namespace _22.ReplaceIdenticalLetters
{
    class ReplaceIdenticalLetters
    {
        static void Main(string[] args)
        {
            string input = "aaaaabbbbbcdddeeeedssaa";
            StringBuilder result = new StringBuilder();
            result.Append(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] != input[i])
                {
                    result.Append(input[i]);
                }
            }
            Console.WriteLine(result);
            
        }
    }
}
