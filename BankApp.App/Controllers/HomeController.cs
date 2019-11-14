using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankApp.App.Models;
using BankApp.Domain;
using BankApp.App.Models.ViewModels;

namespace BankApp.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankRepository repo;
        private HomeViewModel vm;

        public HomeController(BankRepository repo)
        {
            this.repo = repo;
            vm = new HomeViewModel();
        }
        public IActionResult Index()
        {
            vm.Customers = repo.GetAllCustomers().ToList();
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
