using System;
using System.Linq;
using System.Text;

namespace _03.Animals
{
    public class Tomcat :Cat, ISound
    {
        public Tomcat()
        {
        }

        public Tomcat(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = 'M';
        }

        public char Sex { get; set; }


        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendLine("-----Tomcat info-----");
            myBuilder.AppendFormat("Tomcat name: {0}\n", this.Name);
            myBuilder.AppendFormat("Tomcat age: {0}\n", this.Age);
            myBuilder.AppendFormat("Tomcat sex: {0}\n", this.Sex);
            return myBuilder.ToString();
        }
    }
}
