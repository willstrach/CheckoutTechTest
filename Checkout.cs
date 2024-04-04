namespace CheckoutTechTest;

public record Service(string Name, int Price);

public record Discount(string Service, int Quantity, int Price)
{
    public decimal PricePerService => (decimal)Price / (decimal)Quantity;
};

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
            .Where(discount => discount.Service == service && discount.Quantity >= quantity)
            .OrderBy(discount => discount.PricePerService);

        if (!usableServiceDiscounts.Any())
        {
            return basePrice;
        }

        var cumulativePrice = 0;
        var remainingQuantity = quantity;

        foreach (var discount in usableServiceDiscounts)
        {
            var discountQuantity = remainingQuantity / discount.Quantity;
            var remainingServiceQuantity = remainingQuantity % discount.Quantity;

            cumulativePrice += discountQuantity * discount.Price;
            remainingQuantity = remainingServiceQuantity;

            if (remainingQuantity == 0) break;
        }

        if (remainingQuantity > 0)
        {
            cumulativePrice += remainingQuantity * servicePrice;
        }

        return cumulativePrice;
    }
}
