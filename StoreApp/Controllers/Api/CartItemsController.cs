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
    [Route("api/cartitems")]
    public class CartItemsController : Controller
    {
        private IStoreRepository _repository;

        public CartItemsController(IStoreRepository repository)
        {
            _repository = repository;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAllCartItems();
            return Ok(Mapper.Map<IEnumerable<CartItemsViewModel>>(result));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]CartItemsViewModel vm)
        {
            var newCartItem = Mapper.Map<CartItems>(vm);
            _repository.AddCartItem(newCartItem);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
