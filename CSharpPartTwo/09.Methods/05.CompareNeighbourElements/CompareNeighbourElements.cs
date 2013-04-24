using System;
using System.Linq;

namespace _05.CompareNeighbourElements
{
    class CompareNeighbourElements
    {
        static void CompareElements(int position, int[] array) 
        {
            if (position == 0 || position == array.Length - 1)
            {
                Console.WriteLine("Element at position {0} has only one neighbour", position);
            }
            else if ((array[position] > array[position - 1]) && (array[position] > array[position - 1]))
            {
                Console.WriteLine("Element at position {0} is bigger than its neigbours!", position);
            }
            else
            {
                Console.WriteLine("Element at position {0} is smaller or equal to its neighbours!", position);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter element position: ");
            int elementPosition = int.Parse(Console.ReadLine());
            int[] numbers = { 0, 23, 5, 10, 6, 8, 9, 3 };
            CompareElements(elementPosition, numbers);
        }
    }
}
