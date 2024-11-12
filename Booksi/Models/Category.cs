using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Category{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
}