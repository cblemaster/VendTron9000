
namespace Modules.Inventory.Domain.Entities;

internal sealed class InventoryType : Entity<InventoryType>
{
    internal string Name { get; init; }
    public override Identifier<InventoryType> Id { get; init; }

    public InventoryType(string name, Guid id)
    {
        Name = name;
        Id = new Identifier<InventoryType>(id);
    }

    public InventoryType(string name)
    {
        Name = name;
        Id = new Identifier<InventoryType>();
    }
}
