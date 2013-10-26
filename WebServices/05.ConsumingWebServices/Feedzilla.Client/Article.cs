using System;
using System.Linq;

namespace Feedzilla.Client
{
    public class Article
    {
        public string Publish_Date { get; set; }
        public string Source { get; set; }
        public string Source_Url { get; set; }
        public string Summary { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }
    }
}
