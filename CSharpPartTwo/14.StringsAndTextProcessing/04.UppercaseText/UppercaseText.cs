using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04.UppercaseText
{
    class UppercaseText
    {
        static void Main(string[] args)
        {
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            string pattern = @"<upcase>.*?</upcase>";
            string line = "";
            List<string> matches = new List<string>();
            /*-----------Find text between upcase tags---------------*/
            MatchCollection myMatches = Regex.Matches(text, pattern);
            for (int i = 0; i < myMatches.Count; i++)
            {
                line = Regex.Replace(myMatches[i].ToString(),"<upcase>","");
                line = Regex.Replace(line, "</upcase>", "");
                matches.Add(line);
            }
            /*-----------Change matches to uppercase and remove tags---------------*/
            text = Regex.Replace(text, "<upcase>", "");
            text = Regex.Replace(text, "</upcase>", "");
            foreach (var item in matches)
            {
                text = Regex.Replace(text, item, item.ToUpper());
            }
            /*-----------Print result---------------*/
            Console.WriteLine(text);
        }
    }
}
