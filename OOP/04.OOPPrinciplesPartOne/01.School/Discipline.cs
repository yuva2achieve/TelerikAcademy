using System;
using System.Collections.Generic;
using System.Text;

namespace _01.School
{
    public class Discipline : ICommentable
    {
        public string Name { get; set; }
        public int NumberOfExercises { get; set; }
        public int NumberOfLectures { get; set; }
        private readonly List<string> commentsList = new List<string>();

        public Discipline(string name, int exercisesNum, int lecturesNum)
        {
            this.Name = name;
            this.NumberOfExercises = exercisesNum;
            this.NumberOfLectures = lecturesNum;
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
            myBuilder.AppendLine("-----Discipline info-----");
            myBuilder.AppendFormat("Discipline name: {0}\n", this.Name);
            myBuilder.AppendFormat("Number of exercises: {0}\n", this.NumberOfExercises);
            myBuilder.AppendFormat("Number of lectures: {0}\n", this.NumberOfLectures);
            return myBuilder.ToString();
        }
    }
}
