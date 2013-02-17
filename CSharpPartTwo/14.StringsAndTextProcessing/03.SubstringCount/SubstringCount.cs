using System;

namespace _03.SubstringCount
{
    class SubstringCount
    {
        static void Main(string[] args)
        {
            string myString = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string mySubstring = "in";
            myString = myString.ToLower();
            GetSubstringCount(myString,mySubstring);
        }

        static void GetSubstringCount(string input, string substringValue)
        {
            int counter = 0;
            int substringIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                substringIndex = input.IndexOf(substringValue,i);
                if (substringIndex != -1)
                {
                    i = substringIndex;
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
