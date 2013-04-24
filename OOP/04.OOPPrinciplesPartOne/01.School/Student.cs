using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class Student : Person,ICommentable
    {
        public int ClassNumber { get; set; }
        private readonly List<string> commentsList = new List<string>();

        public Student(string name, int number)
        {
            this.Name = name;
            this.ClassNumber = number;
        }
        public void AddComment(string comment)
        {
            this.commentsList.Add(comment);
        }

        public void RemoveComment(int commentPosition)
        {
            this.commentsList.RemoveAt(commentPosition);
        }

        public void PrintComments()
        {
            foreach (var comment in this.commentsList)
            {
                Console.WriteLine(comment);
            }
        }
        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendLine("-----Student info-----");
            myBuilder.AppendFormat("Student name: {0}\n", this.Name);
            myBuilder.AppendFormat("Student number: {0}\n", this.ClassNumber);
            return myBuilder.ToString();
        }
    }
}
