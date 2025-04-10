
namespace Modules.Inventory.Domain.Entities;

public sealed class SnackType : Entity<SnackType>
{
    public string Name { get; init; }
    public IEnumerable<Snack> Snacks { get; init; } = [];
    public override Identifier<SnackType> Id { get; init; }

    private SnackType() { }

    internal SnackType(string name, Guid id)
    {
        Name = name;
        Id = new Identifier<SnackType>(id);
    }

    internal SnackType(string name)
    {
        Name = name;
        Id = new Identifier<SnackType>();
    }
}
