
using Modules.Inventory.Domain.ValueObjects;

namespace Modules.Inventory.Domain.Entities;

public sealed class SnackLocation : Entity<SnackLocation>
{
    public Descriptor Code { get; init; }
    public IEnumerable<Snack> Snacks { get; init; } = [];
    public override Identifier<SnackLocation> Id { get; init; }

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
