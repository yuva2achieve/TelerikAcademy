using System;
using System.Linq;
using System.Text;

namespace _08.ForbiddenWords
{
    class ForbiddenWords
    {
        static void Main(string[] args)
        {
            string[] separator = {", "};
            string forbiddenWords = "PHP, CLR, Microsoft";
            string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            string[] words = forbiddenWords.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] replacements = new string[words.Length];
            StringBuilder myBuilder = new StringBuilder(text);
            for (int i = 0; i < words.Length; i++)
            {
                replacements[i] = new String('*', words[i].Length);
            }
            for (int i = 0; i < words.Length; i++)
            {
                myBuilder.Replace(words[i], replacements[i]);
            }
            Console.WriteLine(myBuilder);
        }
    }
}
