using System;
using System.Linq;

namespace _06.ReturnIndexOfElement
{
    class ReturnIndexOfElement
    {
        static int CompareElements(int position, int[] array)
        {
            if (position == 0)
            {
                return -1;
            }
            else if ((array[position] > array[position - 1]) && (array[position] > array[position + 1]))
            {
                return position;
            }
            else
            {
                return -1;
            }
        }
        static void Main(string[] args)
        {
            int[] numbers = { 0, 15, 30, 45 };
            int result = 0; 
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                result = CompareElements(i, numbers);
                if (result != -1)
                {
                    Console.WriteLine(result);
                    break;
                }
            }
            if (result == -1)
            {
                Console.WriteLine(result);
            }
        }
    }
}
