using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Booksi.Models{
    public class Category{
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 10, ErrorMessage = "Order must be between 1 and 10")]
        public int DisplayOrder { get; set; }
    }
}
