using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models
{
    public class ShopContext:DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ShopProduct> ShopProduct { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options)
               : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Product>()
                .HasKey(x => x.Id);

            builder.Entity<Shop>()
                .HasKey(x => x.Id);

            builder.Entity<ShopProduct>()
                .HasKey(x => new { x.ShopId, x.ProductId });

            builder.Entity<ShopProduct>()
               .HasOne(x => x.Shop)
               .WithMany(m => m.Products)
               .HasForeignKey(x => x.ShopId);
            builder.Entity<ShopProduct>()
                .HasOne(x => x.Product)
                .WithMany(e => e.Shops)
                .HasForeignKey(x => x.ProductId);
            base.OnModelCreating(builder);


            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
