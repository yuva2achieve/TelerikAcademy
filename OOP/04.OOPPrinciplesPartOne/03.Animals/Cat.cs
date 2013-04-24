using System;
using System.Linq;
using System.Text;

namespace _03.Animals
{
    public class Cat : Animal, ISound
    {
        public Cat()
        {
        }

        public Cat(string name, int age, char sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public void MakeSound()
        {
            Console.WriteLine("{0} says miauw", this.Name);
        }

        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendLine("-----Cat info-----");
            myBuilder.AppendFormat("Cat name: {0}\n", this.Name);
            myBuilder.AppendFormat("Cat age: {0}\n", this.Age);
            myBuilder.AppendFormat("Cat sex: {0}\n", this.Sex);
            return myBuilder.ToString();
        }
    }
}
