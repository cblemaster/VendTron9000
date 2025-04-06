
using Modules.Inventory.Domain.Enumerations;

namespace Modules.Inventory.Domain.Entities;

internal class Snack : Entity<Snack>
{
    internal string Label { get; init; }
    internal decimal Price { get; init; }
    internal decimal Cost { get; init; }
    internal SnackType SnackType { get; init; }
    internal string MachineInventoryIndex { get; init; }
    internal Inventory Inventory { get; init; }
    internal DateTimeOffset DateAddedToMachineInventory { get; init; }
    internal override Identifier<Snack> Id { get; init; }

    internal Snack(string label, decimal price, decimal cost, SnackType snackType, string index, Inventory inventory, DateTimeOffset dateAdded, Guid id)
    {
        Label = label;
        Price = price;
        Cost = cost;
        SnackType = snackType;
        MachineInventoryIndex = index;
        Inventory = inventory;
        DateAddedToMachineInventory = dateAdded;
        Id = new Identifier<Snack>(id);
    }

    internal Snack(string label, decimal price, decimal cost, SnackType snackType, string index, Inventory inventory) : this(label, price, cost, snackType, index, inventory, DateTimeOffset.UtcNow, Guid.NewGuid()) { }
}
