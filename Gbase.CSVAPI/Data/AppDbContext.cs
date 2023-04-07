#nullable disable
using Gbase.CSVAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gbase.CSVAPI.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDatabase");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> Pictures { get; set; }
        public DbSet<ProductLink> Links { get; set; }
    }
}
