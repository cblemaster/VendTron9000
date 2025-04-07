
using Modules.Inventory.Domain.Enumerations;

namespace Modules.Inventory.Domain.Entities;

internal class Inventory : Entity<Inventory>
{
    internal IEnumerable<Snack> Snacks { get; init; }

    internal InventoryType InventoryType { get; init; }
    internal override Identifier<Inventory> Id { get; init; }

    internal Inventory(InventoryType inventoryType, IEnumerable<Snack> snacks, Guid id)
    {
        InventoryType = inventoryType;
        Snacks = snacks;
        Id = new Identifier<Inventory>(id);
    }

    internal Inventory(InventoryType inventoryType, IEnumerable<Snack> snacks) : this(inventoryType, snacks, Guid.NewGuid()) { }

    internal void AddSnacks(IEnumerable<Snack> snacks) => Snacks.ToList().AddRange(snacks.Where(s => s.Inventory.InventoryType == InventoryType));

    internal void RemoveSnack(Snack snack)
    {
        if (Snacks.Contains(snack))
        {
            _ = Snacks.ToList().Remove(snack);
        }
    }

    internal IReadOnlyCollection<Snack> GetSnacksAvailableForPurchase() => Snacks.Where(s => s.Inventory.InventoryType == InventoryType.SnacksAvailableForPurchase).OrderBy(s => s.Price).ThenBy(s => s.Label).ThenBy(s => s.SnackType.ToString()).ThenBy(s => s.MachineInventoryIndex).ToList().AsReadOnly();
}
