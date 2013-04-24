using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Dictionary
{
    class Dictionary
    {
        static void Main(string[] args)
        {
            string[] separator = { " – " };
            string[] text = { ".NET – platform for applications from Microsoft",
                                "CLR – managed execution environment for .NET",
                            "namespace – hierarchical organization of classes"
                            };
            var words = new List<string>();
            var definitions = new List<string>();
            bool wordFound = false;
            for (int i = 0; i < text.Length; i++)
            {
                string[] tempArr = text[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                words.Add(tempArr[0]);
                definitions.Add(tempArr[1]);
            }
            Console.Write("Enter word: ");
            string input = Console.ReadLine();
            for (int i = 0; i < words.Count; i++)
            {
                if (input == words[i])
                {
                    Console.WriteLine("{0} - {1}",words[i],definitions[i]);
                    wordFound = true;
                    break;
                }
            }
            if (wordFound == false)
            {
                Console.WriteLine("Word not found!");
            }
        }
    }
}
