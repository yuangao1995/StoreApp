using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

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

        public IActionResult Cart()
        {
            ViewData["Message"] = "Items Added to Your Cart:";
            var data = _repository.GetAllCartItems();
            return View(data);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
