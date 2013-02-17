using System;
using System.Linq;

namespace _02.PrintRandomValues
{
    class PrintRandomValues
    {
        static void Main(string[] args)
        {
            Random myRandomGenerator = new Random();
            byte randomValue = 0;
            for (int i = 0; i < 10; i++)
            {
                randomValue = (byte)myRandomGenerator.Next(100, 201);
                Console.WriteLine(randomValue);
            }
        }
    }
}
