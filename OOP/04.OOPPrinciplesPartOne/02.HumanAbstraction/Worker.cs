namespace _02.HumanAbstraction
{
    using System;
    using System.Linq;
    using System.Text;

    public class Worker : Human
    {
        public Worker()
        {
        }

        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public int WeekSalary { get; set; }

        public int WorkHoursPerDay { get; set; }

        public double MoneyPerHour { get; set; }

        public void CalculateMoneyPerHour()
        {
            this.MoneyPerHour = (this.WeekSalary / 7) / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendLine("-----Worker info-----");
            myBuilder.AppendFormat("Worker first name: {0}\n", this.FirstName);
            myBuilder.AppendFormat("Worker last name: {0}\n", this.LastName);
            myBuilder.AppendFormat("Worker week salary: {0}\n", this.WeekSalary);
            myBuilder.AppendFormat("Worker work hours per day: {0}\n", this.WorkHoursPerDay);
            if (this.MoneyPerHour != 0d)
            {
                myBuilder.AppendFormat("Worker money per hour: {0}\n", this.MoneyPerHour);
            }

            return myBuilder.ToString();
        }
    }
}
