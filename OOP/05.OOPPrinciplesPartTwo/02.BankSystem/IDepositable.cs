using System;
using System.Linq;

namespace _02.BankSystem
{
    public interface IDepositable
    {
        void Deposit(decimal amount);
    }
}
