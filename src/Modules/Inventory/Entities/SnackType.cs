
namespace Modules.Inventory.Domain.Entities;

internal class SnackType : Entity<SnackType>
{
    internal string Descriptor { get; init; } = string.Empty;
    internal override Identifier<SnackType> Id { get; init; }

    internal SnackType(string descriptor, Guid id)
    {
        Descriptor = descriptor;
        Id = new Identifier<SnackType>(id);
    }

    internal SnackType(string descriptor) : this(descriptor, Guid.NewGuid()) { }
}
