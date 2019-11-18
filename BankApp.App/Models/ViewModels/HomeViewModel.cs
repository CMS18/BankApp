using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Domain;

namespace BankApp.App.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Customer> Customers { get; set; }
        
    }
}
