using System;
using System.Linq;
using System.Data.Entity;

namespace TestPerformance
{
    class Program
    {
        private static TelerikAcademyEntities dbContext = new TelerikAcademyEntities();

        static void Main(string[] args)
        {
            // Task 1

            //SelectEmployeesSlow();
            //SelectEmployeesFast();

            // Task 2
            //ToListSlow();
            //ToListFast();
        }

        static void SelectEmployeesSlow()
        {
            using (dbContext)
            {
                foreach (var employee in dbContext.Employees)
                {
                    Console.WriteLine("Employee: {0} {1}; {2}; {3}",
                        employee.FirstName, employee.LastName, employee.Department.Name,
                        employee.Address.Town.Name);
                }
            }
        }

        static void SelectEmployeesFast()
        {
            using (dbContext)
            {
                foreach (var employee in dbContext.Employees.Include(x => x.Department)
                    .Include(x => x.Address.Town))
                {
                    Console.WriteLine("Employee: {0} {1}; {2}; {3}",
                        employee.FirstName, employee.LastName, employee.Department.Name,
                        employee.Address.Town.Name);
                }
            }
        }

        static void ToListSlow()
        {
            using (dbContext)
            {
                var employeesFromSofia = dbContext.Employees.ToList()
                    .Select(x => x.Address).ToList().Select(x => x.Town).ToList()
                    .Where(x => x.Name == "Sofia").ToList();
            }
        }

        static void ToListFast()
        {
            using (dbContext)
            {
                var employeesFromSofia = dbContext.Employees
                    .Select(x => x.Address).Select(x => x.Town)
                    .Where(x => x.Name == "Sofia").ToList();
            }
        }
    }
}
