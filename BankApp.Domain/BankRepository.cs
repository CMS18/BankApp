using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp.Domain
{
    public class BankRepository
    {        
        private static List<Customer> Customers = new List<Customer>
        {
            new Customer
            {
                CustomerId = 1,
                Name = "Ellen",
                Accounts = new List<Account>
                {
                    new Account(1001, 1000),
                    new Account(1002, 2000)
                }

            },
            new Customer
            {
                CustomerId = 2,
                Name = "Ida",
                Accounts = new List<Account>
                {
                    new Account(1003, 3000),
                    new Account(1004, 4000)
                }
            },
            new Customer
            {
                CustomerId = 3,
                Name = "Maria",
                Accounts = new List<Account>
                {
                    new Account(1005, 5000),
                    new Account(1006, 6000)
                }
            }
        };

        public static List<Account> AllAccounts = new List<Account>
        {
            new Account(1001, 1000),
            new Account(1002, 2000),
            new Account(1003, 3000),
            new Account(1004, 4000),
            new Account(1005, 5000),
            new Account(1006, 6000)
        };

        public IList<Customer> GetAllCustomers()
        {
            return Customers;
        }

        public IList<Account> GetAllAccounts()
        {
            return AllAccounts;
        }

        public Account FindAccount(int id)
        {
            Account account = GetAllAccounts()
                .SingleOrDefault(a => a.AccountId == id);
            
            return account;
        }

        public void Transfer(Account from, Account to, decimal amount)
        {
            if(amount > 0 && from.Balance >= amount && int.TryParse(amount.ToString(), out int i))
            {
                from.Balance -= amount;
                to.Balance += amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

    }
}