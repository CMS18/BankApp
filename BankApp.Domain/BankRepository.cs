﻿using System;
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

        public IList<Customer> GetAllCustomers()
        {
            return Customers;
        }
    }
}
