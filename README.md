# Queryable vs Enumerable

## Pill Category

Frameworks (Entity Framework)

## Description

**Known fact: `DbSet` is `IQueriable`**

- In Entity Framework, the `DBSet` class implements `IQueriable` interface. So, all the Linq queries that we write are applied on an `IQueriable` object.

**Cast `IQueriable` to `IEnumerable`**

- But, what happens if we cast this `IQueriable` to `IEnumerable` and then apply the same Linq query?

## Question

- How is the execution affected if we cast the `IQueryable` to `IEnumerable` before applying that Linq query?

## Donations

> If you like my work and want to support me, you can buy me a coffee:
>
> [![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Y8Y62EZ8H)

