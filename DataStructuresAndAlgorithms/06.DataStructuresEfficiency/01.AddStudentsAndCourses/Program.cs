using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.AddStudentsAndCourses
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"../../students.txt";
            StreamReader myReader = new StreamReader(inputFilePath);
            SortedDictionary<string, Course> courses = new SortedDictionary<string, Course>();

            using (myReader)
            {
                while (!myReader.EndOfStream)
                {
                    string line = myReader.ReadLine();
                    string[] arguments = line.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                    Course newCourse = new Course(arguments[2]);
                    Student newStudent = new Student(arguments[0], arguments[1]);
                    if (courses.ContainsKey(newCourse.Name))
                    {
                        courses[newCourse.Name].AddStudent(newStudent);
                    }
                    else
                    {
                        courses.Add(newCourse.Name, newCourse);
                        courses[newCourse.Name].AddStudent(newStudent);
                    }
                }
            }

            foreach (var course in courses.Values)
            {
                Console.WriteLine(course);
            }
        }
    }
}
