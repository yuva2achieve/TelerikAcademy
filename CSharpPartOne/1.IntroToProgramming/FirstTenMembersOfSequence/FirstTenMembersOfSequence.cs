using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Write a program that prints the first 10 members
 * of the sequence: 2, -3, 4, -5, 6, -7, ...*/
namespace FirstTenMembersOfSequence
{
    class FirstTenMembersOfSequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program finds first ten members of the sequence: 2,-3,4,-5,6,-7");
            for (byte number = 2; number <=11; number++)
            {
                if (number%2==0)
                {
                    Console.WriteLine(number);
                }
                else
                {
                    Console.WriteLine(-number);
                }
            }
        }
    }
}
