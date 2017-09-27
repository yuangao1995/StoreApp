using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class StoreUser: IdentityUser
    {
        [Key]
        public int UserId { get; set; }
    }
}
