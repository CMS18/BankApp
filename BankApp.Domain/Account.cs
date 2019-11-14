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
            //guard --- för varje guard skriver jag en egen testmetod
            //för att se att "grindvakterna" funkar
            if (depositAmount < 0) throw new ArgumentOutOfRangeException(nameof(depositAmount),
                "Deposit must be positive");

            Balance = Balance + depositAmount;
        }
    }
}
