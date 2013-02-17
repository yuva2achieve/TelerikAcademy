using System;
using System.Linq;
using System.Text;

namespace _14.ReplaceTags
{
    class ReplaceTags
    {
        static void Main(string[] args)
        {
            string inputText = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
            StringBuilder myBuilder = new StringBuilder(inputText);
            myBuilder.Replace("<a href=", "[URL=");
            myBuilder.Replace("</a>", "[/URL]");
            myBuilder.Replace("\">", "\"]");
            Console.WriteLine(myBuilder);
        }
    }
}
