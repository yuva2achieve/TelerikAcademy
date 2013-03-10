using System;
using System.Linq;

namespace _02.BankSystem
{
    public interface IWithdrawable
    {
        void Withdraw(decimal amount);
    }
}
