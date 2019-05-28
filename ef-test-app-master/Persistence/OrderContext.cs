using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using Persistence.Models;
using System;

namespace Persistence
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base() { }
        public OrderContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuration.LazyLoadingEnabled = false;

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductOrderConfiguration());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
            .Property<DateTime>("LastChanged");

            modelBuilder.Entity<Order>()
            .Property(o => o.CreatedDate)
            .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<ProductOrder>().
                HasKey(po => new { po.OrderID, po.ProductID });
            modelBuilder.Entity<ProductOrder>().
                HasOne(po => po.Product).
                WithMany(p => p.ProductOrders).
                HasForeignKey(po => po.ProductID);
            modelBuilder.Entity<ProductOrder>().
                HasOne(po => po.Order).
                WithMany(o => o.ProductOrders).
                HasForeignKey(po => po.OrderID);

            modelBuilder.Entity<Customer>().
                HasMany(c => c.Orders).
                WithOne(o => o.Customer);

            modelBuilder.Entity<Customer>().
                HasOne(c => c.License).
                WithOne(l => l.Customer).
                HasForeignKey<License>(l => l.CustomerId);
        }
    }
}