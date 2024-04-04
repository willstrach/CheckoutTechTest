# Checkout tech test
Repo containing a solution for the tech test described in [`TASK.md`](./TASK.md). The solution itself can be found in [`Checkout.cs`](./Checkout.cs).

## Assumptions
In completing this task assumptions have been made, some of which result in limitations. 

1. **Integer prices**:

    The suggested interface in the task gives an `int` for the return value of the `GetTotalPrice()` method, implying that prices are integers. Realistically this is a non-issue, as prices could be stored as pence if needed (e.g. `£9.99` becomes `999`).

2. **Only the total price needs to be returned**:

    The suggested interface in the task gives an `int` for the return value of the `GetTotalPrice()` method, implying that only the total price needs to returned. This means than the discounts applied to get to the total are not recorded in any way.

3. **There could exist multiple promotions per service**:

    Discounts increasing with quantity are common, and the task does not rule this out. This could mean that multiple promotions could apply to a quantity of one service (e.g. with promotions of: 5 for £5, and 10 for £9, 14 would cost £14). 
    
     Given the relative simplicity of implementing support for this case, it has been included in the soluton.

2. **No multi-service promotions**: 
    
    The existing promotions in the task apply to one service only. While the solution can support multiple promotions per service, it cannot currently support promotions which offer discounts across multiple services. 

    Supporting multi-service promotions produces an optimisation problem, which likely lies outside of the complexity scope of this task.


## Tests
[Each example described in the task](./TASK.md/#examples-illustrating-discount-application) has a corresponding test. For simplicity, these have been provided alongside the solution in [`CheckoutTests.cs`](./CheckoutTests.cs).

Tests can be run in Visual Studio or by using the `dotnet test` command.
