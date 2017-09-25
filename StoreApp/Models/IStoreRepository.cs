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
        void AddCartItem(CartItems cartItem);
    }
}
