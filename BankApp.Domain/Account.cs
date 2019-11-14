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


    }
}
