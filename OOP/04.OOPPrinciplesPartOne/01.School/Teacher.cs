using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class Teacher : Person,ICommentable
    {
        public List<Discipline> SetOfDisciplines { get; set; }
        private readonly List<string> commentsList = new List<string>();

        public Teacher(string name, List<Discipline> disciplines)
        {
            this.Name = name;
            this.SetOfDisciplines = new List<Discipline>(disciplines);
        }
        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendLine("-----Teacher info-----");
            myBuilder.AppendFormat("Teacher name: {0}\n", this.Name);
            foreach (var discipline in this.SetOfDisciplines)
            {
                myBuilder.Append(discipline);
            }
            return myBuilder.ToString();
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
    }
}
