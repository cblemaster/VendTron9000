
namespace Modules.Inventory.Domain.Entities;

internal class Snack : Entity<Snack>
{
    internal string Label { get; init; }
    internal decimal Price { get; init; }
    internal decimal Cost { get; init; }
    internal SnackType SnackType { get; init; }
    internal string MachineInventoryIndex { get; init; }
    internal DateTimeOffset DateAddedToMachineInventory { get; init; }
    internal override Identifier<Snack> Id { get; init; }

    internal Snack(string label, decimal price, decimal cost, string snackType, string index, DateTimeOffset dateAdded, Guid id)
    {
        Label = label;
        Price = price;
        Cost = cost;
        SnackType = new SnackType(snackType);
        MachineInventoryIndex = index;
        DateAddedToMachineInventory = dateAdded;
        Id = new Identifier<Snack>(id);
    }

    internal Snack(string label, decimal price, decimal cost, string snackType, string index) : this(label, price, cost, snackType, index, DateTimeOffset.UtcNow, Guid.NewGuid()) { }
}
