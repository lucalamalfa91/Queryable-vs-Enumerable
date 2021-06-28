# Is `AsEnumerable` executing the query?

## Conclusion

`AsEnumerable` does not retrieve the data from the database.

It may execute the query on the database (see the 700 millis in Test2), but definitely it does not retrieve the records.

## Measurements

I measured the following aspects:

1) Time to execute the repository method.

2) Time to execute a full iteration over the resulted list.

3) Time to execute a second full iteration over the resulted list.

## Test 1 (Without query conditions)

1.000.000 records

**Repository**

1) ToList

```csharp
return DbContext.Orders
	.ToList();
```

2) AsEnumerable

```csharp
return DbContext.Orders
	.AsEnumerable();
```

3) DbSet

```csharp
return DbContext.Orders;
```

**Results**

|              | Execute Repository Method | First Iteration of Records | Second Iteration of Records |
| ------------ | ------------------------: | -------------------------: | --------------------------: |
| ToList       |               8487 millis |                   8 millis |                    9 millis |
| AsEnumerable |                  1 millis |                8657 millis |                 1170 millis |
| DbSet        |                  0 millis |                9654 millis |                 1296 millis |

## Test 2 (Including query conditions)

1.000.000 records

**Repository**

1) ToList

```csharp
return DbContext.Orders
	.Where(x => x.Date > dateTime)
	.ToList();
```

2) AsEnumerable

```csharp
return DbContext.Orders
	.Where(x => x.Date > dateTime)
	.AsEnumerable();
```

3) DbSet

```csharp
return DbContext.Orders
	.Where(x => x.Date > dateTime);
```

**Results**

|              | Execute Repository Method | First Iteration of Records | Second Iteration of Records |
| ------------ | ------------------------: | -------------------------: | --------------------------: |
| ToList       |               9089 millis |                   9 millis |                    9 millis |
| AsEnumerable |                740 millis |                7675 millis |                 1311 millis |
| DbSet        |                683 millis |                7779 millis |                 1394 millis |

