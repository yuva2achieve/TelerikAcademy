using System;
using System.Linq;
using System.Text;

namespace _03.Animals
{
    public class Frog : Animal, ISound
    {
        public Frog()
        {
        }

        public Frog(string name, int age, char sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public void MakeSound()
        {
            Console.WriteLine("{0} says croak croak", this.Name);
        }

        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendLine("-----Frog info-----");
            myBuilder.AppendFormat("Frog name: {0}\n", this.Name);
            myBuilder.AppendFormat("Frog age: {0}\n", this.Age);
            myBuilder.AppendFormat("Frog sex: {0}\n", this.Sex);
            return myBuilder.ToString();
        }
    }
}
