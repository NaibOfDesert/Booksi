using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Booksi.Utility;

namespace Booksi.Models.Model
{
    public class OrderSummary
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
        public Order Order { get; set; }
        public IEnumerable<int> ShoopingCardListId { get; set; } = new List<int>();
        [ForeignKey("ShoopingCardList")]
        [ValidateNever]
        public IEnumerable<ShoppingCard> ShoppingCardList { get; set;} = new List<ShoppingCard>();

    }
}
