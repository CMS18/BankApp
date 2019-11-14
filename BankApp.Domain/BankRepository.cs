using System;
using System.Collections.Generic;
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
                    new Account
                    {
                        AccountId = 1001,
                        Balance = 1000
                    },
                    new Account
                    {
                        AccountId = 1002,
                        Balance = 2000
                    }
                }

            },
            new Customer
            {
                CustomerId = 2,
                Name = "Ida",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        AccountId = 1003,
                        Balance = 3000
                    },
                    new Account
                    {
                        AccountId = 1004,
                        Balance = 4000
                    }
                }
            },
            new Customer
            {
                CustomerId = 3,
                Name = "Maria",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        AccountId = 1004,
                        Balance = 6000
                    },
                    new Account
                    {
                        AccountId = 1005,
                        Balance = 20000
                    }
                }
            }
        };

        public IList<Customer> GetAllCustomers()
        {
            return Customers;
        }
    }
}
