using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Booksi.Models{
    public class Product{
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, 5000)]
        public dopuble Price {get; set; }
        [Required]
        [Range(1, 5000)]
        [Display(Name = "Extra Price")]
        public dopuble ExtraPrice {get; set; }
    }
}
