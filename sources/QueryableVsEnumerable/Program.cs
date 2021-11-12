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
using System.Collections.Generic;
using System.Linq;

namespace DustInTheWind.QueryableVsEnumerable
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Order> orders = RetrieveRecentOrders();
            DisplayOrders(orders);
        }

        private static List<Order> RetrieveRecentOrders()
        {
            using ShopDbContext dbContext = new ShopDbContext();

            // The `Where` statement is applied on the `IQueryable` instance, while the `OrderBy`
            // is applied after the query was cast to `IEnumerable`.

            DateTime christmasDay = new DateTime(2021, 12, 25);

            return dbContext.Orders
                .Where(x => x.Date >= christmasDay.AddDays(-30))
                .AsEnumerable()
                .OrderBy(x => x.Date)
                .ToList();
        }

        private static void DisplayOrders(IEnumerable<Order> orders)
        {
            foreach (Order order in orders)
            {
                Console.WriteLine("{0} - {1}", order.Id, order.Date);
            }
        }
    }
}