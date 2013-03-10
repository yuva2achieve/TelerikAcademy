using System;
using System.Linq;

namespace _02.BankSystem
{
    public class DepositAccount : Account, IDepositable, IWithdrawable
    {
        // Constructor
        public DepositAccount(Customer owner, decimal balance)
        {
            this.Owner = owner;
            this.Balance = balance;
            if (this.Balance > 0 && this.Balance < 1000)
            {
                this.InterestRate = 0;
            }
            else
            {
                this.InterestRate = 3m;// Default interest of 3%
            }
        }

        //Methods
        public override decimal CalculateInterestAmount(int months)
        {
            decimal interest = months * this.InterestRate;
            return interest;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            try
            {
                if (amount <= this.Balance)
                {
                    this.Balance -= amount;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {

                Console.WriteLine("Insufficient funds!");
                Console.WriteLine("You can only withdraw: {0} leva",this.Balance);
            }
        }
    }
}
