using System;
using System.Linq;

namespace _03.CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            char[] firstArray = {'g', 's', '1', '*', ')'};
            char[] secondArray = { '$', '.', '2', '*', '(' };
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] > secondArray[i])
                {
                    Console.WriteLine("{0} is bigger than {1}", firstArray[i], secondArray[i]);
                }
                if (firstArray[i] < secondArray[i])
                {
                    Console.WriteLine("{0} is smaller than {1}", firstArray[i], secondArray[i]);
                }
                if (firstArray[i] == secondArray[i])
                {
                    Console.WriteLine("{0} is equal to {1}", firstArray[i], secondArray[i]);
                }
            }
        }
    }
}
