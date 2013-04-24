using System;
using System.Linq;
using System.Text;

namespace _02.BankSystem
{
    public class Customer
    {
        public Customer(CustomerType type, string firstName, string lastName)
        {
            this.Type = type;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public CustomerType Type { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendFormat("Customer type: {0}\n", this.Type);
            myBuilder.AppendFormat("First name: {0}\n", this.FirstName);
            myBuilder.AppendFormat("Last name: {0}\n", this.LastName);
            return myBuilder.ToString();
        }
    }
}