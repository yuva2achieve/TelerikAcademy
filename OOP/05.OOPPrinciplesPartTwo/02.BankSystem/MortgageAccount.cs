using System;
using System.Linq;

namespace _02.BankSystem
{
    public class MortgageAccount : Account, IDepositable
    {
        // Constructor
        public MortgageAccount(Customer owner, decimal balance)
        {
            this.Owner = owner;
            this.Balance = balance;
            this.InterestRate = 3m;// Default interest of 3%
        }

        //Methods
        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Owner.Type == CustomerType.Individual)
            {
                if (months <= 6)
                {
                    this.InterestRate = 0m;
                }
                else
                {
                    months -= 6;
                }
            }
            else
            {
                if (months <= 12)
                {
                    this.InterestRate /= 2;
                }
                else
                {
                    months -= 12;
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
