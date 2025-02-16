using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Booksi.Utility;

namespace Booksi.Models.Model{
    public class OrderData{
        public int Id { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        [ValidateNever]
        public AppUser AppUser { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string StreetAddress { get; set; }   
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }


        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Today;
        public DateTime DeliveryDate { get; set; }

        public string? OrderStatus { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
