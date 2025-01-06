using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace Booksi.Models.Model{
    public class Book{
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public double ISBN { get; set; }
        public string? Description { get; set; }
        [Required]
        [Range(1, 5000)]
        public double Price {get; set; }
        [Required]
        [Range(1, 5000)]
        [Display(Name = "Extra Price")]
        public double ExtraPrice {get; set; }
        [ValidateNever] // TOSOLVE: why ValidateNever
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever] // TOSOLVE: why ValidateNever
        public Category Category { get; set; }
    }
}
