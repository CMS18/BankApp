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
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(TransactionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Account account = repo.FindAccount(vm.AccountId);

                if (account == null)
                {
                    ViewBag.Message = "Ogiltigt kontonummer";

                    return View("Index");
                }

                account.Deposit(vm.Amount);
                if(account.Message != null)
                {
                    ViewBag.Message = account.Message;
                    return View("Index");
                }

                vm.NewBalance = account.Balance;

                return View("TransactionFeedBack", vm);
            }
            else
            {
                ViewBag.Message = "Något gick fel, var god försök igen";
                return View("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(TransactionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Account account = repo.FindAccount(vm.AccountId);

                if (account == null)
                {
                    ViewBag.Message = "Ogiltigt kontonummer";

                    return View("Index");
                }

                account.Withdraw(vm.Amount);

                if (account.Message != null)
                {
                    ViewBag.Message = account.Message;
                    return View("Index");
                }

                vm.NewBalance = account.Balance;

                return View("TransactionFeedBack", vm);
            }
            else
            {
                ViewBag.Message = "Något gick fel, var god försök igen";
                return View("Index");
            }
        }

    

}


}
