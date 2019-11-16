using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.App.Models.ViewModels;
using BankApp.Domain;
using Microsoft.AspNetCore.Mvc;


namespace BankApp.App.Controllers
{
    public class TransactionController : Controller
    {
        private readonly BankRepository repo;
        private TransactionViewModel vm;

        public TransactionController(BankRepository repo)
        {
            this.repo = repo;
            vm = new TransactionViewModel();
        }
        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(TransactionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var id = vm.AccountId;
                Account account = repo.GetAllAccounts()
                    .SingleOrDefault(a => a.AccountId == id);

                if (account == null)
                {
                    TempData["Message"] = "Ogiltigt kontonummer";

                    return RedirectToAction("Index");
                }

                account.Deposit(vm.Amount);

                vm.NewBalance = account.Balance;

                return View("TransactionFeedBack", vm);
            }
            else
            {
                TempData["Message"] = "Något gick fel, var god försök igen";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(TransactionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var id = vm.AccountId;
                Account account = repo.GetAllAccounts()
                    .SingleOrDefault(a => a.AccountId == id);

                if (account == null)
                {
                    TempData["Message"] = "Ogiltigt kontonummer";

                    return RedirectToAction("Index");
                }

                account.Withdraw(vm.Amount);

                vm.NewBalance = account.Balance;

                return View("TransactionFeedBack", vm);
            }
            else
            {
                TempData["Message"] = "Något gick fel, var god försök igen";
                return RedirectToAction("Index");
            }
        }

    

}


}
