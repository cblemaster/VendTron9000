
using Modules.Inventory.Domain.ValueObjects;

namespace Modules.Inventory.Domain.Entities;

internal sealed class SnackLocation : Entity<SnackLocation>
{
    internal Descriptor Code { get; init; }
    internal IEnumerable<Snack> Snacks { get; init; } = [];
    internal override Identifier<SnackLocation> Id { get; init; }

    private SnackLocation() { }
    
    public SnackLocation(string code, Guid id)
    {
        Code = new Descriptor(code);
        Id = new Identifier<SnackLocation>(id);
    }

    public SnackLocation(string code)
    {
        Code = new Descriptor(code);
        Id = new Identifier<SnackLocation>();
    }
}
