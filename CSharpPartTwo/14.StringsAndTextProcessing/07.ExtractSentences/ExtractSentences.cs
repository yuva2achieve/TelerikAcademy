using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07.ExtractSentences
{
    class ExtractSentences
    {
        static void Main(string[] args)
        {
            string[] separators = {". "};
            string regExPattern = @"\bin\b";
            string input = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string[] str = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < str.Length; i++)
            {
                if (Regex.IsMatch(str[i],regExPattern))
                {
                    Console.WriteLine(str[i]);
                }
            }

        }
    }
}
