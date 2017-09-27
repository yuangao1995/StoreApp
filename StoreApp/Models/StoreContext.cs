using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class StoreContext : IdentityDbContext<StoreUser> 
    {
        public StoreContext(DbContextOptions options) 
      : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<StoreUser> StoreUser { get; set; }

    }

}
