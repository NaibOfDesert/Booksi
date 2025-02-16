using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Booksi.Utility;

namespace Booksi.Models.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        [ValidateNever]
        public AppUser AppUser { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [ValidateNever]
        public OrderData OrderData { get; set; }
        public int BookId {  get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }  

    }
}
