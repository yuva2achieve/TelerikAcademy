using System;
using System.Linq;
using System.Text;

namespace _02.BankSystem
{
    public abstract class Account
    {
        // Fields
        private Customer owner;
        private decimal balance;
        private decimal interestRate;

        // Properties
        public Customer Owner
        {
            get { return owner; }
            protected set { owner = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            protected set
            {
                try
                {
                    if (value >= 0)
                    {
                        this.balance = value;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Balance must be bigger or equal to 0!");
                }
            }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            protected set { this.interestRate = value; }
        }

        // Methods
        public abstract decimal CalculateInterestAmount(int months);

        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendLine("------Account Info-----");
            myBuilder.Append(this.owner);
            myBuilder.AppendFormat("Balance: {0} leva\n", this.balance);
            myBuilder.AppendFormat("Interest rate: {0}%\n", this.interestRate);
            myBuilder.AppendLine("-----------------------");
            return myBuilder.ToString();
        }
    }
}
