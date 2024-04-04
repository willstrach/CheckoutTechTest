using Xunit;

namespace CheckoutTechTest;

public class CheckoutTests
{ 
    [Fact]
    // See Example 1 TASK.md
    public void GetTotalPrice_UsingExample1_ShouldReturn20()
    {
        // Arrange
        var checkout = new Checkout(CheckoutTestData.Services, CheckoutTestData.Discounts);
        checkout.Scan("B");
        checkout.Scan("B");

        // Act
        var totalPrice = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(20, totalPrice);

    }

    [Fact]
    // See Example 2 in TASK.md
    public void GetTotalPrice_UsingExample2_ShouldReturn23()
    {
        // Arrange
        var checkout = new Checkout(CheckoutTestData.Services, CheckoutTestData.Discounts);
        checkout.Scan("F");
        checkout.Scan("C");

        // Act
        var totalPrice = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(23, totalPrice);
    }

    [Fact]
    // See Example 3 in TASK.md
    public void GetTotalPrice_UsingExample3_ShouldReturn27()
    {
        // Arrange
        var checkout = new Checkout(CheckoutTestData.Services, CheckoutTestData.Discounts);
        checkout.Scan("F");
        checkout.Scan("F");
        checkout.Scan("B");

        // Act
        var totalPrice = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(27, totalPrice);
    }

    [Fact]
    public void GetTotalPrice_WithNoServices_ShouldReturn0()
    {
        // Arrange
        var checkout = new Checkout(CheckoutTestData.Services, CheckoutTestData.Discounts);

        // Act
        var totalPrice = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(0, totalPrice);
    }

    [Fact]
    public void GetTotalPrice_WithMultipleDiscountsForAService_ShouldUseMultipleDiscounts()
    {
        // Arrange
        List<Discount> discounts = [..CheckoutTestData.Discounts, new("A", 2, 18)];
        var checkout = new Checkout(CheckoutTestData.Services, discounts);
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");

        // Act
        var totalPrice = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(43, totalPrice);
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
