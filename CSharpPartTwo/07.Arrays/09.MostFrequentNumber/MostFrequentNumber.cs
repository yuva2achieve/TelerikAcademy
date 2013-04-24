using System;
using System.Linq;

namespace _09.MostFrequentNumber
{
    class MostFrequentNumber
    {
        static void Main(string[] args)
        {
            int[] numbers = {4,1,1,4,2,3,4,4,1,2,4,9,3};
            int numValue = 0;//Current number value
            int biggestNumValue = 0;//Value of most common number
            int elementCount = 1;//Current number count
            int biggestElementCount = 1;//Best number count
            Array.Sort(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > numValue)
                {
                    numValue = numbers[i];
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if (numValue == numbers[j])
                        {
                            elementCount++;
                            if (elementCount > biggestElementCount)
                            {
                                biggestElementCount = elementCount;
                                biggestNumValue = numValue;
                            }
                        }
                        else
                        {
                            elementCount = 1;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("{0} ({1} times)", biggestNumValue, biggestElementCount);
        }
    }
}
