using System;
using System.Linq;

namespace _01.KnapsackProblem
{
    public class Product
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }

        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }
    }
}
