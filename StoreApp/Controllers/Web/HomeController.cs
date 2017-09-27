using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository _repository;

        public HomeController(IStoreRepository repository)
        {
            _repository = repository; 
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to the Store!";
            return View();
        }
        [Authorize]
        public IActionResult Cart()
        {
            ViewData["Message"] = "Items Added to Your Cart:";
            var data = _repository.GetCartItemsByUser(this.User.Identity.Name);
            return View(data);
        }

        public IActionResult CartNoLogin()
        {
            ViewData["Message"] = "Please Login To View Your Shopping Cart";
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Cart", "Home");
            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
