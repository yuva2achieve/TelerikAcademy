using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ReverseIntegerSequence
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Stack<int> sequence = new Stack<int>();
            GetSequence(sequence);
            PrintSequenceInReversedOrder(sequence);
        }

        private static void GetSequence(Stack<int> sequence)
        {
            Console.Write("Enter sequence length: ");
            int lenth = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < lenth; i++)
            {    
                string input = Console.ReadLine();
                int inputValue = int.Parse(input);
                sequence.Push(inputValue);
            }
        }

        private static void PrintSequenceInReversedOrder(Stack<int> sequence)
        {
            Console.WriteLine("-----------Reversed sequence-----------");
            while (sequence.Count > 0)
            {
                Console.WriteLine(sequence.Pop());
            }
        }
    }
}
