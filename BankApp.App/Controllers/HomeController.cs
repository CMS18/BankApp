using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankApp.App.Models;
using BankApp.Domain;

namespace BankApp.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankRepository repo;

        public HomeController(BankRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            repo.GetAllCustomers();
            return View();
            //Gör en lista på startsidan med alla kunder och 
            //deras konto på startsidan. 


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
