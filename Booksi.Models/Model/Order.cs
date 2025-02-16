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
        public int Id { get; set; }
        public int OrderDataId { get; set; }
        [ForeignKey("OrderDataId")]
        [ValidateNever]
        public OrderData OrderData { get; set; }
        public int BookId {  get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }  

    }
}
