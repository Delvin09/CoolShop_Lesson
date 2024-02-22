using CoolShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolShop.Entity.SqlServer
{
    public class CoolShopContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public CoolShopContext(DbContextOptions<CoolShopContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();

            modelBuilder.Entity<Product>().HasIndex(p => p.Name);

            base.OnModelCreating(modelBuilder);
        }
    }
}
