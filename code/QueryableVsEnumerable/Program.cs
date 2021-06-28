using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryableVsEnumerable
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

            return dbContext.Orders
                .Where(x => x.Date >= DateTime.Today.AddDays(-30))
                //.AsEnumerable()
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