namespace _02.HumanAbstraction
{
    using System;
    using Angela.Core;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var students = 
                Angie.Configure<Student>()
                .Fill(p => p.FirstName).AsFirstName()
                .Fill(p => p.LastName).AsLastName()
                .Fill(p => p.Grade).WithinRange(2, 7)
                .MakeList<Student>(10);
            var workers =
                Angie.Configure<Worker>()
                .Fill(p => p.FirstName).AsFirstName()
                .Fill(p => p.LastName).AsLastName()
                .Fill(p => p.WeekSalary).WithinRange(300, 1001)
                .Fill(p => p.WorkHoursPerDay).WithinRange(2, 10)
                .MakeList<Worker>(10);
            foreach (var worker in workers)
            {
                worker.CalculateMoneyPerHour();
            }

            var studentsAscending =
                from student in students
                orderby student.Grade ascending
                select student;
            var workersDescending =
                from worker in workers
                orderby worker.MoneyPerHour descending
                select worker;
            foreach (var student in studentsAscending)
            {
                Console.WriteLine(student);
            }

            foreach (var worker in workersDescending)
            {
                Console.WriteLine(worker);
            }
        }
    }
}
