using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Domain
{
    public class Account
    {
        public decimal Balance { get; set; }
        public int AccountId { get; set; }

        public string Message { get; set; }

        public Account(int accountId, decimal balance)
        {
            this.AccountId = accountId;
            this.Balance = balance;           
        }

        public void Deposit(decimal depositAmount)
        {
            //guard --- för varje guard skriver jag en egen testmetod
            //för att se att "grindvakterna" funkar
            try
            {
                if (depositAmount < 0) throw new ArgumentOutOfRangeException(nameof(depositAmount),
                                                                       "Deposit can not be negative");
            }
            catch (Exception ex)
            {
                this.Message = ex.Message;
                return;
            }

            this.Message = null;
            Balance = Balance + depositAmount;
        }

        public void Withdraw(decimal withdrawAmount)
        {
            //guards
            try
            {
                if (withdrawAmount > Balance) throw new ArgumentOutOfRangeException(nameof(withdrawAmount),
                     "No coverage for this withdraw");
                if (withdrawAmount < 0) throw new ArgumentOutOfRangeException(nameof(withdrawAmount),
                     "Withdraw can not be negative");
            }
            catch (Exception ex)
            {
                this.Message = ex.Message;
                return;
            }

            this.Message = null;
            Balance = Balance - withdrawAmount;
        }
    }
}
