#nullable disable
using Gbase.CSVAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gbase.CSVAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable(nameof(Product));
                p.Property(d => d.Price).HasPrecision(18, 2);
                p.HasMany(p => p.Pictures).WithOne();
            });
            modelBuilder.Entity<ProductPicture>(p =>
            {
                p.ToTable(nameof(ProductPicture));
            });
            modelBuilder.Entity<ProductLink>(p =>
            {
                p.ToTable(nameof(ProductLink));
            });
            modelBuilder.Entity<ProductType>(p =>
            {
                p.ToTable(nameof(ProductType));
                p.HasData(ProductType.Types);
            });
            modelBuilder.Entity<ProductCase>(p =>
            {
                p.ToTable(nameof(ProductCase));
                p.HasData(ProductCase.Cases);
            });
            modelBuilder.Entity<ProductCondition>(p =>
            {
                p.ToTable(nameof(ProductCondition));
                p.HasData(ProductCondition.Conditions);
            });
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> Pictures { get; set; }
        public DbSet<ProductCondition> Conditions { get; set; }
        public DbSet<ProductType> Types { get; set; }
        public DbSet<ProductLink> Links { get; set; }
        public DbSet<ProductCase> Cases { get; set; }
    }
}
