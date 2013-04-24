using System;
using System.Linq;

namespace _02.BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            DepositAccount depositAcc = new DepositAccount(
                new Customer(CustomerType.Individual, "Pesho", "Petrov"), 1100m);
            LoanAccount loanAcc = new LoanAccount(
                new Customer(CustomerType.Company, "Pesho", "Petrov"), 800m);
            MortgageAccount mortgageAcc = new MortgageAccount(
                new Customer(CustomerType.Individual, "Pesho", "Petrov"), 800m);

            // Uncomment next lines to test Deposit() and Withdraw()
            //Console.WriteLine(depositAcc);
            //depositAcc.Deposit(120m);
            //depositAcc.Withdraw(20000m);
            //Console.WriteLine(depositAcc);
            //depositAcc.Withdraw(1220m);
            //Console.WriteLine(depositAcc);

            // Uncomment next lines to test CalculateInterestAmount()
            Console.WriteLine(depositAcc.CalculateInterestAmount(6));
            Console.WriteLine(loanAcc.CalculateInterestAmount(12));
            Console.WriteLine(mortgageAcc.CalculateInterestAmount(6));
        }
    }
}
