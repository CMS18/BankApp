using BankApp.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.App.Controllers
{
    public class TransferController : Controller
    {
        private readonly BankRepository repo;
        public TransferController(BankRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transfer(int fromAccount, int toAccount, decimal amount)
        {
            var fromaccount = BankRepository.AllAccounts.SingleOrDefault(a => a.AccountId == fromAccount);
            var toaccount = BankRepository.AllAccounts.SingleOrDefault(a => a.AccountId == toAccount);
            if (fromAccount == toAccount)
            {
                TempData["info"] = "It is not possible to transfer to the same account";
            }
            else if (fromaccount != null || toaccount != null)
            {
                try
                {
                    repo.Transfer(fromaccount, toaccount, amount);
                    TempData["info"] = $"Successfully transfered from account {fromaccount.AccountId} (new balance: {fromaccount.Balance})" + $"to account {toaccount.AccountId} (new balance {toaccount.Balance})";
                }
                catch (ArgumentOutOfRangeException)
                {
                    TempData["info"] = "Invalid amount";
                }
            }
            else
            {
                TempData["info"] = "invalid id";
            }
            return View("Index");
        }
    }
}
