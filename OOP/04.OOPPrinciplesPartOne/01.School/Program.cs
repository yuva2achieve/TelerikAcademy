using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.School
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher testTeacher = 
                new Teacher("Mr. Burnes",
                new List<Discipline>()
                {
                    new Discipline("History",5,5),
                    new Discipline("Math",6,4)
                });
            Student testStudentOne = new Student("Ivan Ivanov", 2156);
            Student testStudentTwo = new Student("Georgi Petrov", 2015);
            SchoolClass testSchoolClass = new SchoolClass("Computer Science",
                new List<Teacher>()
                {
                    testTeacher
                });
            School testSchool = new School(new List<SchoolClass>()
            {
                testSchoolClass
            });
            testStudentOne.AddComment("Scored A in Object Oriented Programming");
            testStudentOne.AddComment("Scored D in Calculus");
            // Uncomment next line to print Teacher
            // Console.WriteLine(testTeacher);

            // Uncomment next two lines to print two students
            // Console.WriteLine(testStudentOne);
            // Console.WriteLine(testStudentTwo);

            // Uncomment next line to print SchoolClass
            // Console.WriteLine(testSchoolClass);

            // Uncomment next line to print School
            // Console.WriteLine(testSchool);

            // Uncomment next line to print comments for first student
            // testStudentOne.PrintComments();
        }
    }
}
