
namespace Modules.Inventory.Domain.Entities;

internal abstract class Entity<T>
{
    internal abstract Identifier<T> Id { get; init; }

    internal Entity(Guid id) => Id = new Identifier<T>(id);

    internal Entity() => Id = new Identifier<T>();
}
