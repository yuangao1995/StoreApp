﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class CartItems
    {
        [Key]
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProdId { get; set; }
        public int Qty { get; set; }
        public decimal CPrice { get; set; }
    }
}
