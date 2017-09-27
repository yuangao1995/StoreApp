using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using AutoMapper;
using StoreApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
            try
            {
                //var result = _repository.GetAllCartItems();
                var result = _repository.GetCartItemsByUser(this.User.Identity.Name);
                return Ok(Mapper.Map<IEnumerable<CartItemsViewModel>>(result));
            }
            catch (Exception ex)
            {
                //still need to add logger
                return BadRequest("Failed to get items");
            }

        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]CartItemsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var newCartItem = Mapper.Map<CartItems>(vm);

                newCartItem.UserName = User.Identity.Name;

                _repository.AddCartItem(newCartItem);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/cartitems/{vm.Name}",
                    Mapper.Map<CartItemsViewModel>(newCartItem));
                }
            }
            return BadRequest("Failed to add item to cart");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var todelete = _repository.GetCartItemById(id);
                if (todelete == null)
                {
                    return NotFound();
                }
                _repository.RemoveCartItem(todelete);
                return Ok(todelete);
            }
            return BadRequest("Failed to delete item from cart");
        }
    }
}
