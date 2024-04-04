namespace CheckoutTechTest;

public interface ICheckout
{
    void Scan(string service); // Adds a service to the checkout
    int GetTotalPrice(); // Calculates the total price, applying the best discount option
}
