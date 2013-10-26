using System;
using System.Linq;
using StudentSystem.Models;

namespace StudentSystem.Services.Models
{
    public class MarkModel
    {
        public MarkModel(Mark mark)
        {
            this.Id = mark.Id;
            this.Subject = mark.Subject;
            this.Value = mark.Value;
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public int Value { get; set; }
    }
}