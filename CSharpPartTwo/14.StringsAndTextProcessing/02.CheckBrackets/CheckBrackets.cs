using System;
using System.Linq;

namespace _02.CheckBrackets 
{
    class CheckBrackets
    {
        static void Main(string[] args)
        {
            string myString = ")(smeaaha) agagag (gsgsgs)";
            CheckExpression(myString);
        }

        static void CheckExpression(string input)
        {
            int counter = 0;
            foreach (var item in input)
            {
                if (item == '(')
                {
                    counter++;
                }
                else if (item == ')')
                {
                    counter--;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Expression is valid!");
            }
            else
            {
                Console.WriteLine("Invalid expression!");
            }
        }
    }
}
