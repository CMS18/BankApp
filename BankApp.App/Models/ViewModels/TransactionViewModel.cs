using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.App.Models.ViewModels
{
    public class TransactionViewModel
    {
        [Required(ErrorMessage = "Required field")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        //[MaxLength(4, ErrorMessage = "AccountId should be 4 characters")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Required field")]
        public decimal Amount { get; set; }

        public decimal NewBalance { get; set; }
    }
}
