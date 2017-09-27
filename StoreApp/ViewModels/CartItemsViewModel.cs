using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.ViewModels
{
    public class CartItemsViewModel
    {
        public int CartItemId { get; set; }
        public int UserName { get; set; }
        public int ProdId { get; set; }
        public int Qty { get; set; }
        public decimal CPrice { get; set; }
        public string Name { get; set; }
    }
}
