using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.PrintVariations
{
    class PrintVariations
    {
        static void GetVariations(int start, int[] array, int stop)
        {
            if (start == array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = 1; i <= stop; i++)
                {
                    array[start] = i;
                    GetVariations(start + 1, array,stop);
                }
            }
        }

        static void Print(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter N:");
            int n = int.Parse(Console.ReadLine());
            int[] myArray = new int[k];
            GetVariations(0, myArray, n);
        }
    }
}
