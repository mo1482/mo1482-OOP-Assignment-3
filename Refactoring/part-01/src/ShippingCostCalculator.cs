namespace RefactoringLab;

public interface IShippingCarrier
{
    string Name { get; }
    decimal CalculateCost(decimal weightKg);
}

public sealed class AramexCarrier : IShippingCarrier
{
    public string Name => "Aramex";
    public decimal CalculateCost(decimal weightKg) => weightKg * 12m;
}

public sealed class FedExCarrier : IShippingCarrier
{
    public string Name => "FedEx";
    public decimal CalculateCost(decimal weightKg) => weightKg * 15m;
}

public sealed class DhlCarrier : IShippingCarrier
{
    public string Name => "DHL";
    public decimal CalculateCost(decimal weightKg) => weightKg * 18m;
}

// New carrier: no existing carrier or calculator class needs editing.
public sealed class UpsCarrier : IShippingCarrier
{
    public string Name => "UPS";
    public decimal CalculateCost(decimal weightKg) => weightKg * 14m;
}

public sealed class ShippingCostCalculator
{
    private readonly IReadOnlyDictionary<string, IShippingCarrier> _carriers;

    public ShippingCostCalculator(IEnumerable<IShippingCarrier>? carriers = null)
    {
        var defaults = carriers ?? new IShippingCarrier[]
        {
            new AramexCarrier(), new FedExCarrier(), new DhlCarrier()
        };
        _carriers = defaults.ToDictionary(c => c.Name, StringComparer.OrdinalIgnoreCase);
    }

    public decimal Calculate(string carrier, decimal weightKg)
    {
        if (weightKg < 0) throw new ArgumentOutOfRangeException(nameof(weightKg));
        if (!_carriers.TryGetValue(carrier, out var selected))
            throw new ArgumentException($"Unknown carrier: {carrier}", nameof(carrier));
        return selected.CalculateCost(weightKg);
    }
}
