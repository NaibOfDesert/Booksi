using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class ApplicationDbContext : DbContext
{
    public DbSet <Category> Categories{ get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category {Id = 1, Name = "Historical"},
            new Category {Id = 2, Name = "Political"},
            new Category {Id = 3, Name = "SciFi"},
            new Category {Id = 4, Name = "Crime"}
        ); 
    }
}