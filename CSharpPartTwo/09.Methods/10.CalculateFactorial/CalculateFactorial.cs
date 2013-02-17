using System;
using System.Linq;
using System.Numerics;
namespace _10.CalculateFactorial
{
    class CalculateFactorial
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            BigInteger factorialValue = GetFactorialValue(number);
            Console.WriteLine("{0}! = {1}", number, factorialValue);
        }
        static BigInteger GetFactorialValue(int num)
        {
            BigInteger result = 2;
            if (num == 2)
            {
                return num;
            }
            else
            {
                for (int i = 3; i <= num; i++)
                {
                    result *= i;
                }
            }
            return result;
        }
    }
}
