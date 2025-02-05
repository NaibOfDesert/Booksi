using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Booksi.Models.Model
{
	public class ShoppingCard
	{
        public int Id { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public AppUser User { get; set; }

        [Range(1, 10)]
        public int BooksCount { get; set; }

        public ShoppingCard()
		{
	
		}
	}
}

