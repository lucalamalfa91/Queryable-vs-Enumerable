# Questions

## Prerequisites

- Create a database and a table with 1.000.000 records.
- Create a console application with Entity Framework, including a custom `DbContext` for the previously created table.

## 1) Query is not executed until `ToList` is called

- Start a Profiler instance on the database.
- Create a query (without a call to `ToList`) that includes a `Where` condition.
- In a second statement add a call to `ToList`.
- Run the code using the debugger and look in the parallel in the Profiler.
  - The query appears in the Profiler only when the `ToList` method is called.

## 2) `IQueriable` is executed on the database server

- Start a Profiler instance on the database.
- Create a query that includes a `Where` condition and execute it.
- Check the profiler.
  - The `Where` condition should be visible in the profiler.

## 3) `IEnumerable` is executed in process

- Start a Profiler instance on the database.
- Create a query that includes a `Where` condition and execute it.
- Add to the query a call to `AsEnumerable` and a second `Where` condition.
- Execute the query.
- Check the profiler.
  - Only the first `Where` condition should be visible in the profiler.

## 4) There is no difference between `AsEnumerable` and a simple cast to `IEnumerable`

- Start a Profiler instance on the database.
- Create a query that includes a `Where` condition and execute it.
- Cast the query to `IEnumerable` and add a second `Where` condition.
- Execute the query.
- Check the profiler.
  - Only the first `Where` condition should be visible in the profiler.

## 5) A second iteration over the database items is quicker

- Create and use a `Stopwatch` instance to measure the execution time of the iteration.
- Iterate over the database items.
- Create and use a second `Stopwatch` instance to measure the execution time of the second iteration.
- Iterate again over the database items.
- Compare the times.
  - Second run is about 5 times faster.