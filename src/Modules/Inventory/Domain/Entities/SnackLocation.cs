
using Modules.Inventory.Domain.ValueObjects;

namespace Modules.Inventory.Domain.Entities;

public sealed class SnackLocation : Entity<SnackLocation>
{
    public Descriptor Code { get; init; }
    public Snack Snack { get; init; } = default!;
    public Identifier<Snack> SnackId { get; init; }
    public override Identifier<SnackLocation> Id { get; init; }

    private SnackLocation() { }

    public SnackLocation(string code, Guid snackId, Guid snackLocationId)
    {
        Code = new Descriptor(code);
        Id = new Identifier<SnackLocation>(snackLocationId);
        SnackId = new Identifier<Snack>(snackId);
    }
}
