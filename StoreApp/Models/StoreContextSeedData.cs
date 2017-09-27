using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class StoreContextSeedData
    {
        private StoreContext _context;
        private UserManager<StoreUser> _userManager;

        public StoreContextSeedData(StoreContext context, UserManager<StoreUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if (await _userManager.FindByEmailAsync("example2@StoreApp.com") == null)
            {
                var user = new StoreUser()
                {
                    UserName = "example2@StoreApp.com",
                    Email = "example2@StoreApp.com"
                };

               var r = await _userManager.CreateAsync(user, "Password_123");
            }

            if (await _userManager.FindByEmailAsync("example3@StoreApp.com") == null)
            {
                var user = new StoreUser()
                {
                    UserName = "example3@StoreApp.com",
                    Email = "example3@StoreApp.com"
                };

                var r = await _userManager.CreateAsync(user, "Password_123");
            }


            if (!_context.Products.Any())
            {
                var prod1 = new Products()
                {
                    Name = "Monitor",
                    Description = "New Computer Monitor for sale",
                    Price = 100.0m,
                    ImageURL = "prod1.jpg"
                };
                _context.Add(prod1);

                var prod2 = new Products()
                {
                    Name = "Mouse",
                    Description = "New Mouse for sale",
                    Price = 30.0m,
                    ImageURL = "prod2.jpg"
                };
                _context.Add(prod2);

                var prod3 = new Products()
                {
                    Name = "Keyboard",
                    Description = "New Keyboard for sale",
                    Price = 20.0m,
                    ImageURL = "prod3.jpg"
                };
                _context.Add(prod3);

                var prod4 = new Products()
                {
                    Name = "Computer Case",
                    Description = "New Computer Case for sale",
                    Price = 50.0m,
                    ImageURL = "prod4.jpg"
                };
                _context.Add(prod4);

                var prod5 = new Products()
                {
                    Name = "Speakers",
                    Description = "New Speakers for sale",
                    Price = 40.0m,
                    ImageURL = "prod5.jpg"
                };
                _context.Add(prod5);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
