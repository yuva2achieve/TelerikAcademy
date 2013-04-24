using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animals
{
    public class Kitten : Cat
    {

        public Kitten()
        {
        }

        public Kitten(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = 'F';
        }

        public char Sex { get; set; }


        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendLine("-----Kitten info-----");
            myBuilder.AppendFormat("Kitten name: {0}\n", this.Name);
            myBuilder.AppendFormat("Kitten age: {0}\n", this.Age);
            myBuilder.AppendFormat("Kitten sex: {0}\n", this.Sex);
            return myBuilder.ToString();
        }
    }
}
