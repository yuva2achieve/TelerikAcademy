using System;
using System.Linq;

namespace _02.BankSystem
{
    public class LoanAccount : Account, IDepositable
    {
        // Constructor
        public LoanAccount(Customer owner, decimal balance)
        {
            this.Owner = owner;
            this.Balance = balance;
            this.InterestRate = 3m;// Default interest of 3%
        }

        // Methods
        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Owner.Type == CustomerType.Individual)
            {
                if (months <= 3)
                {
                    this.InterestRate = 0m;
                }
                else
                {
                    months -= 3;
                }
            }
            else
            {
                if (months <= 2)
                {
                    this.InterestRate = 0m;
                }
                else
                {
                    months -= 2;
                }
            }
            decimal interest = months * this.InterestRate;
            return interest;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
    }
}
