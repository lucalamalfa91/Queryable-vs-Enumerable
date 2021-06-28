# Queryable vs Enumerable

## Problem Description

**Known: `DbSet` is `IQueriable`**

- We know that, in Entity Framework, the `DBSet` class implements `IQueriable` interface. So, all the Linq queries that we write are applied on an `IQueriable` object.

> The decompiled `DbSet`:
>
> ```csharp
> public abstract class DbSet<TEntity> : IQueryable<TEntity>, IAsyncEnumerable<TEntity>, IInfrastructure<IServiceProvider>, IListSource
>  where TEntity : class
> ```

**Step 1: Cast `IQueriable` to `IEnumerable`**

- But, what happens if we cast this `IQueriable` to `IEnumerable`. By the way, we can do that because it inherits `IEnumerable`.
  We also know that a cast does not change the instance in any other way in the memory. We interact with the same instance but using the specified interface to which we casted it to. So, it is the same old `IQueriable` object, but now, we see it as an `IEnumerable`.

> The decompiled `IQueryable`:
>
> ```csharp
> public interface IQueryable<[Nullable(2)] out T> : IEnumerable<T>, IEnumerable, IQueryable
> ```

**Step 2: Execute same Linq query**

- We will apply the same Linq query on the `IEnumerable` instead of `IQueryable`.

**Question**

- Does the execution change in any way?