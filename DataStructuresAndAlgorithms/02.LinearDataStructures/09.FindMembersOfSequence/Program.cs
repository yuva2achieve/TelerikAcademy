using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.FindMembersOfSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                int sequenceMember = sequence.Dequeue();
                Console.WriteLine(sequenceMember);
                sequence.Enqueue(sequenceMember + 1);
                sequence.Enqueue(2 * sequenceMember + 1);
                sequence.Enqueue(sequenceMember + 2);
            }
        }
    }
}
