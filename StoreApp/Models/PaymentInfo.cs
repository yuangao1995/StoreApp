using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StoreApp.Models
{
    public class PaymentInfo
    {
        [Key]
        public int PaymentInfoId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CardNumber { get; set; }
        public int CVVNumber { get; set; }
    }
}
