using System;
using Microsoft.EntityFrameworkCore;

namespace QueryableVsEnumerable
{
    internal class ShopDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                const string connectionString = "Data Source=localhost;Initial Catalog=QueryableVsEnumerable;Integrated Security=True;MultipleActiveResultSets=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DateTime today = DateTime.Today;

            //   -55   -48   -40    -10    -7    -1    0
            // ------------------   ---------------------
            //     last month           current month

            Order[] initialOrders = {
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = today
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = today.AddDays(-55)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = today.AddDays(-7)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = today.AddDays(-10)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = today.AddDays(-40)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = today.AddDays(-1)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = today.AddDays(-48)
                }
            };

            modelBuilder.Entity<Order>()
                .HasData(initialOrders);
        }
    }
}