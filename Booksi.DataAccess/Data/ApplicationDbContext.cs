using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Booksi.Models.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace Booksi.DataAccess.Data{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<AppUser> Users { get; set; }   
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Book> Books{ get; set; }
        public DbSet<ShoppingCard> ShoppingCards { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            // Configuration to Identity
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, Name = "Historical"},
                new Category {Id = 2, Name = "Political"},
                new Category {Id = 3, Name = "SciFi"},
                new Category {Id = 4, Name = "Crime"}
            ); 

            modelBuilder.Entity<Book>().HasData(
                new Book {
                    Id = 1, 
                    Title = "The Rise and Fall of the Third Reich: A History of Nazi Germany", 
                    Author="William L. Shirer", 
                    ISBN = 9780330700016,
                    Description = @"Hitler boasted that The Third Reich would last a thousand years. It lasted only 12.
                        But those 12 years contained some of the most catastrophic events Western civilization has ever known.
                        No other powerful empire ever bequeathed such mountains of evidence about its birth and destruction as the Third Reich.
                        When the bitter war was over, and before the Nazis could destroy their files, the Allied demand for unconditional surrender produced an
                        almost hour-by-hour record of the nightmare empire built by Adolph Hitler. This record included the testimony of Nazi
                        leaders and of concentration camp inmates, the diaries of officials, transcripts of secret conferences, army orders,
                        private letters—all the vast paperwork behind Hitler's drive to conquer the world. 
                        The famed foreign correspondent and historian William L. Shirer, who had watched and reported on the Nazis since 1925, 
                        spent five and a half years sifting through this massive documentation. The result is a monumental study that has been widely 
                        acclaimed as the definitive record of one of the most frightening chapters in the history of mankind.
                        This worldwide bestseller has been acclaimed as the definitive book on Nazi Germany; it is a classic work.
                        The accounts of how the United States got involved and how Hitler used Mussolini and Japan are astonishing, and the 
                        coverage of the war-from Germany's early successes to her eventual defeat-is must reading.",
                    Price = 100,
                    ExtraPrice = 80,
                    ImageUrl = "", 
                    CategoryId = 1
                }
            ); 
        }
    }
}
