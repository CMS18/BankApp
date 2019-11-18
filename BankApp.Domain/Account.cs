using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain
{
    public class Account
    {
        public decimal Balance { get; set; }
        public int AccountId { get; set; }

        public Account(int accountId, decimal balance)
        {
            this.AccountId = accountId;
            this.Balance = balance;
        }

        public void Deposit(decimal depositAmount)
        {
            //1 guard
            if (depositAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(depositAmount),
                    "Negative deposit not possible");
            else
                Balance = Balance + depositAmount;
        }

        public void Withdraw(decimal withdrawAmount)
        {
            //2 guards
            if (withdrawAmount > Balance) throw new ArgumentOutOfRangeException(nameof(withdrawAmount),
                 "No coverage for this withdraw");
            if (withdrawAmount < 0) throw new ArgumentOutOfRangeException(nameof(withdrawAmount),
                 "Withdraw can not be negative");
            else
                Balance = Balance - withdrawAmount;
        }
    }
}
