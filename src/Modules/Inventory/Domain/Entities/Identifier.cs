
namespace Modules.Inventory.Domain.Entities;

public sealed class Identifier<T>(Guid value)
{
    public Guid Value { get; init; } = value;

    public Identifier() : this(Guid.NewGuid()) { }
}
