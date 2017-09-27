using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public interface IStoreRepository
    {
        IEnumerable<Products> GetAllProducts();
        Products GetProductById(int Id);
        IEnumerable<CartItems> GetAllCartItems();
        CartItems GetCartItemById(int Id);
        void AddCartItem(CartItems cartItem);
        void RemoveCartItem(CartItems cartItem);
        Task<bool> SaveChangesAsync();
        IEnumerable<CartItems> GetCartItemsByUser(string name);
    }
}
