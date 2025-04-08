
namespace Modules.Inventory.Domain.ValueObjects;

public record struct Currency(decimal Amount, string CurrencyType = "USD");
