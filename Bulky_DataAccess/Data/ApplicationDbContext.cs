using Bulky_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky_Web.Data
{
    public class ApplicationDbContext : DbContext
    {

        //options zijn bv. connection string
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        // een eigenschap an het type dbset die de naam Categories heeft en van het type Category is. 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }

    }


}
