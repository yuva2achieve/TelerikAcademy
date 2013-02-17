using System;
using System.Linq;

namespace _08.SequenceOfMaxSum
{
    class SequenceOfMaxSum
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            int currentSum = 0;//Current sum of the sequence
            int maxSum = 0;//Maximal sum of the sequence
            int startPosition = 0;//First element of sequence
            int endPosition = 0;//Last element of the sequence
            for (int i = 0; i < numbers.Length; i++)
            {
                currentSum = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    currentSum += numbers[j];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startPosition = i;
                        endPosition = j;
                    }
                }
            }
            for (int i = startPosition; i <= endPosition; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
        }
    }
}
