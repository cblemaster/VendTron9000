
namespace Modules.Inventory.Domain.ValueObjects;

internal record struct Currency(decimal Amount, string CurrencyType = "USD");
