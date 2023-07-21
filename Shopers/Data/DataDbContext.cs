using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopers.Models.Authentication;
using Shopers.Models.Product;

namespace Shopers.Data
{
    public class DataDbContext : IdentityDbContext<ProfileUser>
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)"); // replace with your desired column type
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
        }
        public DbSet<Category> categories { get; set; } 
        public DbSet<Product> products { get; set; }
        public DbSet<ProductImage> productImages { get; set; }
    }
}
