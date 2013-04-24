namespace _02.HumanAbstraction
{
    using System;
    using System.Linq;
    using System.Text;

    public class Student : Human
    {
        public Student()
        {
        }

        public Student(string firstName, string lastName, int grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public int Grade { get; set; }

        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendLine("-----Student info-----");
            myBuilder.AppendFormat("Student first name: {0}\n", this.FirstName);
            myBuilder.AppendFormat("Student last name: {0}\n", this.LastName);
            myBuilder.AppendFormat("Student grade: {0}\n", this.Grade);
            return myBuilder.ToString();
        }
    }
}
