# `Queriable` vs `Enumerable`

## Preparation Recipe

- Create a Console Application project and add Entity Framework. Nuget packages:

  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`

- Create domain entity:

  - `Order`

```csharp
internal class Order
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
}
```

- Create `ShopDbContext`:

  - `OnConfiguring` - set connection string

```csharp
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
}
```

- Create migration and execute it:
  - `Initial`
  - Note: This will create the SQL Server database: `QueryableVsEnumerable`
- Populate `Orders` table:

```sql
INSERT [dbo].[Orders] ([Id], [Date])
VALUES (N'b7b2146e-a44a-41f7-bc4a-089f587ce389', CAST(N'2021-09-14T00:00:00.0000000' AS DateTime2))

INSERT [dbo].[Orders] ([Id], [Date])
VALUES (N'6061535e-db49-4242-b7b4-38178e96a573', CAST(N'2021-09-05T00:00:00.0000000' AS DateTime2))

INSERT [dbo].[Orders] ([Id], [Date])
VALUES (N'a8a2deaa-f995-4434-aab5-9241d3d23129', CAST(N'2021-08-06T00:00:00.0000000' AS DateTime2))

INSERT [dbo].[Orders] ([Id], [Date])
VALUES (N'fe7bb0be-7bd8-4805-94fe-942342081631', CAST(N'2021-09-15T00:00:00.0000000' AS DateTime2))

INSERT [dbo].[Orders] ([Id], [Date])
VALUES (N'df834f16-5156-42cd-a525-a324339f5d4d', CAST(N'2021-07-29T00:00:00.0000000' AS DateTime2))

INSERT [dbo].[Orders] ([Id], [Date])
VALUES (N'e9909cc9-ff4e-45f8-9ee6-d31f0a5fed2e', CAST(N'2021-09-08T00:00:00.0000000' AS DateTime2))

INSERT [dbo].[Orders] ([Id], [Date])
VALUES (N'c6237471-f738-4e43-a502-e1476447ccc8', CAST(N'2021-07-22T00:00:00.0000000' AS DateTime2))
```

- a) Create a Linq query:
  - Add a `Where` and an `OrderBy` statement.

```csharp
IQueryable<Order> query = dbContext.Orders
    .Where(x => x.Date >= dateTime)
    .OrderBy(x => x.Date);
```

- Start a SQL Profiler and run the Console Application.

  - Highlight that the query executed in the SQL Server contains the `WHERE` and `ORDER BY` clauses.

- b) Split the query in two: one part containing the `Where`  call and the other containing the `OrderBy` call. Cast the first part, the one with the `Where`, to `IEnumerable<Order>`.

```csharp
IEnumerable<Order> query1 = (IEnumerable<Order>)dbContext.Orders
	.Where(x => x.Date >= dateTime);

IEnumerable<Order> query2 = query1
	.OrderBy(x => x.Date);
```

- Run the application again and highlight in the SQL Server Profiler that the query executed in the SQL Server contains only the `WHERE` clause.

- c) Replace the cast with a call to `AsEnumerable` before the `OrderBy` statement in the Linq query.

```csharp
IEnumerable<Order> query = (IEnumerable<Order>)dbContext.Orders
    .Where(x => x.Date >= dateTime)
    .AsEnumerable()
    .OrderBy(x => x.Date);
```

- Run the application again and highlight in the SQL Server Profiler that the query does not contain the `ORDER BY` clause anymore.
