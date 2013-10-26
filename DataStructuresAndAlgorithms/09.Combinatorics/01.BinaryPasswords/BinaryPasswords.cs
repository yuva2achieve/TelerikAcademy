using System;
using System.Linq;

namespace _01.BinaryPasswords
{
    class BinaryPasswords
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int asterixCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    asterixCount++;
                }
            }

            long combinationsCount = (long)Math.Pow(2, asterixCount);
            Console.WriteLine(combinationsCount);
        }
    }
}
