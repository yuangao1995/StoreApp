using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class StoreRepository : IStoreRepository
    {
        private StoreContext _context;

        public StoreRepository(StoreContext context)
        {
            _context = context;
        }
        //gets products into a list from context
        public IEnumerable<Products> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Products GetProductById(int Id)
        {
            return _context.Products.Where(x => x.ProdId == Id).Single();
        }

        public void AddCartItem(CartItems cartItem)
        {
            _context.Add(cartItem);
            _context.SaveChanges();
        }

        public IEnumerable<CartItems> GetAllCartItems()
        {
            return _context.CartItems.ToList();
        }
    }
}
