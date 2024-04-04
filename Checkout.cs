namespace CheckoutTechTest;

public record Service(string Name, int Price);
public record Discount(string Service, int Quantity, int Price);

public class Checkout(IEnumerable<Service> services, IEnumerable<Discount> discounts) : ICheckout
{
    private readonly IEnumerable<Service> _services = services;
    private readonly IEnumerable<Discount> _discounts = discounts;
    private readonly Dictionary<string, int> _basket = new();
    
    public void Scan(string service)
    {
        if (!_services.Any(s => s.Name == service))
        {
            throw new ArgumentException($"Service '{service}' not found", nameof(service));
        }

        _basket.TryGetValue(service, out var currentQuantity);
        _basket[service] = currentQuantity + 1;
    }

    public int GetTotalPrice()
    {
        if (this._basket.Count == 0) return 0;
        var totalPrice = _basket.Sum(sq => GetPriceForServiceQuantity(sq.Key, sq.Value));
        return totalPrice;
    }

    private int GetPriceForServiceQuantity(string service, int quantity)
    {
        var servicePrice = _services.First(s => s.Name == service).Price;
        var basePrice = servicePrice * quantity;

        var usableServiceDiscounts = _discounts
            .Where(discount => discount.Service == service && discount.Quantity <= quantity);

        if (!usableServiceDiscounts.Any())
        {
            return basePrice;
        }

        List<int> allPossiblePrices = [basePrice];

        foreach (var discount in usableServiceDiscounts)
        {
            var discountQuantity = quantity / discount.Quantity;
            var remainingServiceQuantity = quantity % discount.Quantity;

            var discountedPrice = (discountQuantity * discount.Price) + (remainingServiceQuantity * servicePrice);
            allPossiblePrices.Add(discountedPrice);
        }

        return allPossiblePrices.Min();
    }
}
