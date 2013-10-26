using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSystem.Models
{
    public class School
    {
        private ICollection<Student> students;

        public School()
        {
            this.students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Students can't be null");
                }

                this.students = value;
            }
        }
    }
}