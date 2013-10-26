using System;
using System.Linq;
using System.Text;

namespace _02.RetrieveArticlesInPriceRange
{
    public class Article : IComparable<Article>
    {
        public string Barcode { get; set; }
        public string Vendor { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public Article(string barcode, string vendor, string title, int price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public int CompareTo(Article other)
        {
            if (this.Price < other.Price)
            {
                return -1;
            }
            else if (this.Price > other.Price)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendFormat("{0}, {1}, {2}, {3}", this.Barcode, this.Vendor, this.Title, this.Price);
            myBuilder.AppendLine();
            return myBuilder.ToString();
        }
    }
}
