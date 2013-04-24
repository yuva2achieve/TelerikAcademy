using System;
using System.Collections.Generic;
using System.Text;

namespace _01.School
{
    public class SchoolClass : ICommentable
    {
        public string ClassIdentifier { get; set; }
        public List<Teacher> TeachersList { get; set; }
        private readonly List<string> commentsList = new List<string>();

        public SchoolClass(string identifier, List<Teacher> teachersList)
        {
            this.ClassIdentifier = identifier;
            this.TeachersList = new List<Teacher>(teachersList);
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
            myBuilder.AppendLine("-----School class info-----");
            myBuilder.AppendFormat("Scool class identifier: {0}\n", this.ClassIdentifier);
            foreach (var teacher in this.TeachersList)
            {
                myBuilder.Append(teacher);
            }
            return myBuilder.ToString();
        }
    }
}
