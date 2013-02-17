using System;
using System.Linq;
using System.Text;

namespace _05.PrintAsterix
{
    class PrintAsterix
    {
        static void Main(string[] args)
        {
            string inputString = "a";
            int maxLength = 20;
            StringBuilder result = new StringBuilder();
            result.Append(inputString);
            if (inputString.Length < maxLength)
            {
                for (int i = 0; i < maxLength - inputString.Length; i++)
                {
                    result.Append('*');
                }
            }
            Console.WriteLine(result);
        }
    }
}
