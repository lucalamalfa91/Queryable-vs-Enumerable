// C# Pills 15mg
// Copyright (C) 2021 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using Microsoft.EntityFrameworkCore;

namespace DustInTheWind.QueryableVsEnumerable
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

            DateTime christmasDay = new DateTime(2021, 12, 25);

            //   -55   -48   -40    -10    -7    -1    0
            // ------------------   ---------------------
            //     last month           current month

            Order[] initialOrders = {
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = christmasDay
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = christmasDay.AddDays(-55)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = christmasDay.AddDays(-7)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = christmasDay.AddDays(-10)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = christmasDay.AddDays(-40)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = christmasDay.AddDays(-1)
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = christmasDay.AddDays(-48)
                }
            };

            modelBuilder.Entity<Order>()
                .HasData(initialOrders);
        }
    }
}