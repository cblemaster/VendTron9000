
namespace Modules.Inventory.Domain.Entities;

public sealed class Identifier<T>
{
    public Guid Value { get; init; }

    public Identifier(Guid value) => Value = value;
    internal Identifier() : this(Guid.NewGuid()) { }
}
