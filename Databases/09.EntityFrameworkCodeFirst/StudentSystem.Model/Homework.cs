using System;

namespace StudentSystem.Model
{
    public class Homework
    {
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }
    }
}