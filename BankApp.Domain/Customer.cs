using System;
using System.Collections.Generic;

namespace BankApp.Domain
{
    public class Customer
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }

        public List<Account> Accounts { get; set; }

    }
}
