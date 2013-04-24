using System;
using System.Linq;

namespace _01.PrintUserName
{
    class PrintUserName
    {
        static string GetUserName()
        {
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();
            return userName;
        }
        static void PrintName(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
        static void Main(string[] args)
        {
            string userName = GetUserName();
            PrintName(userName);
        }
    }
}
