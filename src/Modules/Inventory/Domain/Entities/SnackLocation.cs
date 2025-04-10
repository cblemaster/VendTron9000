
using Modules.Inventory.Domain.ValueObjects;

namespace Modules.Inventory.Domain.Entities;

public sealed class SnackLocation : Entity<SnackLocation>
{
    public Descriptor Code { get; init; }
    public Snack Snack { get; init; } = default!;
    public Identifier<Snack> SnackId { get; init; }
    public override Identifier<SnackLocation> Id { get; init; }

    private SnackLocation() { }

    internal SnackLocation(string code, Guid snackId)
    {
        Code = new Descriptor(code);
        SnackId = new Identifier<Snack>(snackId);
        Id = new Identifier<SnackLocation>();
    }
}
