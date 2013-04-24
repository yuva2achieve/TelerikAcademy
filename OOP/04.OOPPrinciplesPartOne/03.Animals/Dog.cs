using System;
using System.Linq;
using System.Text;

namespace _03.Animals
{
    public class Dog : Animal, ISound
    {
        public Dog()
        {
        }

        public Dog(string name, int age, char sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }
            
        public void MakeSound()
        {
            Console.WriteLine("{0} says woof woof", this.Name);
        }

        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendLine("-----Dog info-----");
            myBuilder.AppendFormat("Dog name: {0}\n", this.Name);
            myBuilder.AppendFormat("Dog age: {0}\n", this.Age);
            myBuilder.AppendFormat("Dog sex: {0}\n", this.Sex);
            return myBuilder.ToString();
        }
    }
}
