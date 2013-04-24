using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignStringToObject
{
    class AssignStringToObject
    {
        static void Main(string[] args)
        {
            string firstWord = "Hello ";
            string secondWord = "World";
            string twoWords = firstWord + secondWord;
            Console.WriteLine(twoWords);
            object fullSentence = twoWords;
            Console.WriteLine(fullSentence);
        }
    }
}
