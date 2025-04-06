
namespace Modules.Inventory.Domain.Entities;

internal sealed class Identifier<T>
{
    internal Guid Value { get; init; }
    
    internal Identifier(Guid value) => Value = value;
    internal Identifier() : this(Guid.NewGuid()) { }
}
