using Xunit;

namespace CheckoutTechTest;

public class CheckoutTests
{  
    public static ICheckout GetCheckoutInstance() => new Checkout(CheckoutTestData.Services, CheckoutTestData.Discounts);

    [Fact]
    // See Example 1 TASK.md
    public void GetTotalPrice_UsingExample1_ShouldReturn20()
    {
        // Arrange
        var checkout = GetCheckoutInstance();

        // Act
        checkout.Scan("B");
        checkout.Scan("B");
        var totalPrice = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(20, totalPrice);

    }

    [Fact]
    // See Example 2 in TASK.md
    public void GetTotalPrice_UsingExample2_ShouldReturn23()
    {
        // Arrange
        var checkout = GetCheckoutInstance();

        // Act
        checkout.Scan("F");
        checkout.Scan("C");
        var totalPrice = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(23, totalPrice);
    }

    [Fact]
    // See Example 3 in TASK.md
    public void GetTotalPrice_UsingExample3_ShouldReturn27()
    {
        // Arrange
        var checkout = GetCheckoutInstance();

        // Act
        checkout.Scan("F");
        checkout.Scan("F");
        checkout.Scan("B");
        var totalPrice = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(27, totalPrice);
    }

    [Fact]
    public void GetTotalPrice_WithNoServices_ShouldReturn0()
    {
        // Arrange
        var checkout = GetCheckoutInstance();

        // Act
        var totalPrice = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(0, totalPrice);
    }
}

public static class CheckoutTestData
{
    public static List<Service> Services = [
        new("A", 10),
        new("B", 12),
        new("C", 15),
        new("D", 25),
        new("F", 8)
    ];

    public static List<Discount> Discounts = [
        new("A", 3, 25),
        new("B", 2, 20),
        new("F", 2, 15)
    ];
}
