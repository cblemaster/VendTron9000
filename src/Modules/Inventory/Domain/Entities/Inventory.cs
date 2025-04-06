
using Modules.Inventory.Domain.Enumerations;

namespace Modules.Inventory.Domain.Entities;

internal class Inventory : Entity<Inventory>
{
    private readonly IEnumerable<Snack> _snacks;

    internal InventoryType InventoryType { get; init; }
    internal override Identifier<Inventory> Id { get; init; }

    internal Inventory(InventoryType inventoryType, IEnumerable<Snack> snacks, Guid id)
    {
        _snacks = snacks;
        InventoryType = inventoryType;
        Id = new Identifier<Inventory>(id);
    }

    internal Inventory(InventoryType inventoryType, IEnumerable<Snack> snacks) : this(inventoryType, snacks, Guid.NewGuid()) { }


    internal void AddSnacks(IEnumerable<Snack> snacks) => _snacks.ToList().AddRange(snacks);

    internal void RemoveSnack(Snack snack)
    {
        if (_snacks.Contains(snack))
        {
            _ = _snacks.ToList().Remove(snack);
        }
    }

    internal IReadOnlyCollection<Snack> GetSnacksAvailableForPurchase() => _snacks.Where(s => s.Inventory.InventoryType == InventoryType.SnacksAvailableForPurchase).OrderBy(s => s.Price).ThenBy(s => s.Label).ThenBy(s => s.SnackType.ToString()).ThenBy(s => s.MachineInventoryIndex).ToList().AsReadOnly();
}
