using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.AddStudentsAndCourses
{
    public class Course
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public Course(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
        }

        public int StudentsCount
        {
            get
            {
                return this.Students.Count;
            }
        }

        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }

        public override string ToString()
        {
            var studentsInOrder =
                from student in this.Students
                orderby student.LastName ascending
                orderby student.FirstName ascending
                select student;

            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendFormat("{0}: ", this.Name);
            foreach (var student in studentsInOrder)
            {
                myBuilder.AppendFormat("{0}, ", student.ToString());
            }

            myBuilder.Length -= 2;

            return myBuilder.ToString();
        }
    }
}
