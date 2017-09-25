using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using AutoMapper;
using StoreApp.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreApp.Controllers.Api
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private IStoreRepository _repository;

        public ProductsController(IStoreRepository repository)
        {
            _repository = repository; 
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAllProducts();
            return Ok(Mapper.Map<IEnumerable<ProductViewModel>>(result));
        }

        [HttpGet("{prodid}")]
        [Route("api/products/{prodid}")]
        public Products GetProductById(int prodid)
        {
            var result = _repository.GetProductById(prodid);
            return result;
        }
    }
    
}
