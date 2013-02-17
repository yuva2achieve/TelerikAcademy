using System;
using System.Linq;

namespace _12.AlphabetArray
{
    class AlphabetArray
    {
        static void Main(string[] args)
        {
            int n = 26;
            char[] alphabet = new char[n];
            char letterValue = 'A';
            string word = "Hello World";
            word = word.ToUpper();
            for (int i = 0; i < n; i++)
            {
                alphabet[i] = letterValue;
                letterValue++;
            }
            foreach (var letter in word)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (letter == alphabet[i])
                    {
                        Console.Write("{0} ",i);
                    }
                }
            }
        }
    }
}
