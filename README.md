# Checkout tech test
Repo containing a solution for the tech test described in [`TASK.md`](./TASK.md). The solution itself can be found in [`Checkout.cs`](./Checkout.cs).

## Assumptions
In completing this task, assumptions have been made. These assumptions give rise to limitations in the solution.

1. **Integer prices**: The suggested interface in the task uses `int` for the return value of the `GetTotalPrice()` method, implying that prices are integers. The task lists prices in pounds, but if pence were required, prices could either be multiplied by 100, or `decimal` could be used. 

2. **No multi-service promotions**: The existing promotions in the task apply to one service only. While the solution can support multiple promotions per service, it cannot currently support promotions which offer discounts across multiple services.

## Tests
[Each example described in the task](./TASK.md/#examples-illustrating-discount-application) has a corresponding test. For simplicity, these have been provided alongside the solution in [`CheckoutTests.cs`](./CheckoutTests.cs).

Tests can be run in Visual Studio or by using the `dotnet test` command.
