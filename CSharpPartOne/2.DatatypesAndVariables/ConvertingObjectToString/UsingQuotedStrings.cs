using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertingObjectToString
{
    class UsingQuotedStrings
    {
        static void Main(string[] args)
        {
            string quotedString = @"The ""use"" of quotations causes difficulties.";
            string usingEscapeSequence = "The \"use\" of quotations causes difficulties.";
            Console.WriteLine(quotedString);
            Console.WriteLine(usingEscapeSequence);
        }
    }
}
