
namespace Modules.Inventory.Domain.Entities;

internal sealed class SnackType : Entity<SnackType>
{
    internal string Name { get; init; }
    internal override Identifier<SnackType> Id { get; init; }
    internal IEnumerable<Snack> Snacks { get; init; } = [];

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
