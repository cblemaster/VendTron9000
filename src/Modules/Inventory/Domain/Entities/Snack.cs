
using Modules.Inventory.Domain.ValueObjects;

namespace Modules.Inventory.Domain.Entities;

internal class Snack : Entity<Snack>
{
    internal Descriptor Label { get; init; }
    internal Currency Price { get; init; }
    internal Currency Cost { get; init; }
    internal SnackType SnackType { get; init; } = default!;
    internal Identifier<SnackType> SnackTypeId { get; init; }
    internal SnackLocation SnackLocation { get; init; } = default!;
    internal Identifier<SnackLocation> SnackLocationId { get; init; }
    internal override Identifier<Snack> Id { get; init; }

    private Snack() { }

    internal Snack(string label, decimal price, decimal cost, Guid snackTypeId, Guid snackLocationId, Guid snackId)
    {
        ValidateParams(label, price, cost);

        Label = new Descriptor(label);
        Price = new Currency(price);
        Cost = new Currency(cost);
        SnackTypeId = new Identifier<SnackType>(snackTypeId);
        SnackLocationId = new Identifier<SnackLocation>(snackLocationId);
        Id = new Identifier<Snack>(snackId);

        static void ValidateParams(string label, decimal price, decimal cost)
        {
            if (string.IsNullOrWhiteSpace(label) || label.Length > 12)
            {
                throw new ArgumentException("Label is required and must be fewer than 12 characters in length...", nameof(label));
            }
            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be greater than zero...");
            }
            if (cost <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cost), "Cost must be greater than zero...");
            }
        }
    }
}
