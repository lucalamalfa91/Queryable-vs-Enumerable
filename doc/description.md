# `Queriable` vs `Enumerable`

## Category

Frameworks (Entity Framework)

## Description

- Q: Does casting `IQueriable` to `IEnumerable` make any difference in the execution?
- A: Yes.
  - Highlight that `IQueriable` is executed in SQL Server and `IEnumerable` is executed in the application's process (C#).

## Plan

- Create a Console Application project and add Entity Framework. Nuget packages:

  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`

- Create domain entity:

  - `Order`.

- Create `ShopDbContext`:

  - `OnConfiguring` - connection string
  - `OnModelCreating` - order seeding

- Create a SQL Server database:

  - `QueryableVsEnumerable`

- Create migration and execute it:

  - `Initial`

- Create a Linq query:

  - Add a `Where` and an `OrderBy` statement.

- Start a SQL Profiler and run the Console Application.

  - Highlight that the query executed in the SQL Server contains the `WHERE` and `ORDER BY` clauses.

- Add a call to `AsEnumerable` before the `OrderBy` statement in the Linq query.

  - Run the application again and highlight in the SQL Server Profiler that the query does not contain the `ORDER BY` clause anymore.

  Note: Try the same thing but replace the `AsEnumerable` with a simple cast to `IEnumerable`.