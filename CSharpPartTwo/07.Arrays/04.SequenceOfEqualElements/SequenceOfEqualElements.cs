using System;
using System.Linq;

namespace _04.SequenceOfEqualElements
{
    class SequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
            int initialSeq = 1;//Stores current sequence
            int maximalSeq = 1;//Stores longest sequence
            int sequenceValue = 0;//Stores elements of the sequence
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    initialSeq++;
                    if (initialSeq > maximalSeq)
                    {
                        maximalSeq = initialSeq;
                        sequenceValue = numbers[i];
                    }                    
                }
                else
                {
                    initialSeq = 1;
                }
            }
            for (int i = 0; i < maximalSeq; i++)
            {
                Console.Write("{0} ", sequenceValue);
            }
        }
    }
}
