using System;
using System.Linq;

namespace _05.MaxIncreasingSequence
{
    class MaxIncreasingSequence
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 2, 5, 8, 2, 7, 3, 0, 4, 5, 7, 8 };
            int initialSeq = 1;//Current sequence
            int maxSequence = 1;//Longest sequence
            int lastElement = 0;//Last element in the sequence
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] < numbers[i + 1])
                {
                    initialSeq++;
                    if (initialSeq > maxSequence)
                    {
                        maxSequence = initialSeq;
                        lastElement = i + 1;
                    }
                }
                else
                {
                    initialSeq = 1;
                }
            }
            if (initialSeq > maxSequence)
            {
                maxSequence = initialSeq;
                lastElement = numbers.Length - 1;
            }
            for (int i = lastElement - (maxSequence - 1); i <= lastElement ; i++)
            {
                Console.Write("{0} ", numbers[i] );
            }
        }
    }
}
