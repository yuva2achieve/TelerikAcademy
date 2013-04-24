using System;
using System.Linq;
using System.Text;

namespace _01.ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string myString = Console.ReadLine();
            StringBuilder reversedString = new StringBuilder();
            for (int i = myString.Length - 1; i >= 0; i--)
            {
                reversedString.Append(myString[i]);
            }
            Console.WriteLine(reversedString);
        }
    }
}
