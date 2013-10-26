using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.FindProductsInRange
{
    public class Product: IComparable
    {
        private string name;
        private int price;

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendFormat("Name: {0}, Price: {1}", this.Name, this.Price);

            return myBuilder.ToString();
        }

        public int CompareTo(object obj)
        {
            var otherProduct = obj as Product;
            int otherPrice = otherProduct.Price;

            return this.Price.CompareTo(otherPrice);
        }
    }
}
