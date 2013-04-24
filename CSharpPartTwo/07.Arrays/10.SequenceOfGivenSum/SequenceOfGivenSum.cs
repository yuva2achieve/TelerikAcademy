using System;
using System.Linq;

namespace _10.SequenceOfGivenSum
{
    class SequenceOfGivenSum
    {
        static void Main(string[] args)
        {
            int s = 11;
            int[] numbers = { 4, 3, 1, 4, 2, 5, 8 };
            int currentSum = 0;
            int startPosition = 0;
            int endPosition = 0;
            bool isThereSuchSum = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                currentSum = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    currentSum += numbers[j];
                    if (currentSum == s)
                    {
                        isThereSuchSum = true;
                        startPosition = i;
                        endPosition = j;
                    }
                }
            }
            if (isThereSuchSum == false)
            {
                Console.WriteLine("The sum is not present in this array!");
            }
            if (isThereSuchSum == true)
            {
                for (int i = startPosition; i <= endPosition; i++)
                {
                    Console.Write("{0} ", numbers[i]);
                }
            }
        }
    }
}
