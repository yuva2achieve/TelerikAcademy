using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSystem.Models
{
    public class Student
    {
        private ICollection<Mark> marks;

        public Student()
        {
            this.Marks = new List<Mark>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<Mark> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Marks can't be null");
                }
                
                this.marks = value;
            }
        }
    }
}
