using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace Booksi.Models.Model{
    public class AppUser : IdentityUser{
        // [Required]
        public string Name { get; set;}
        // [Required]
        public string LastName { get; set;}

        public string? Country { get; set;} 
        public string? City { get; set;}
        public string? Street { get; set;}
        public string? PostalCode { get; set;}
    }
}