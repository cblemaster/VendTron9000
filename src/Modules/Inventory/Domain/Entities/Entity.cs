
namespace Modules.Inventory.Domain.Entities;

internal abstract class Entity<T>
{
    internal abstract Identifier<T> Id { get; init; }
}
