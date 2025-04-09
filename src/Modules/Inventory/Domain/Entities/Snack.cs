
using Modules.Inventory.Domain.Enumerations;
using Modules.Inventory.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace Modules.Inventory.Domain.Entities;

internal class Snack : Entity<Snack>
{
    internal Descriptor Label { get; init; }
    internal Currency Price { get; init; }
    internal Currency Cost { get; init; }
    internal SnackType SnackType { get; init; }
    internal Inventory Inventory { get; init; }
    internal Identifier<Inventory> InventoryId { get; init; }
    internal DateTimeOffset DateAddedToInventory { get; init; }
    internal override Identifier<Snack> Id { get; init; }

    private Snack() { }
    internal Snack(string label, decimal price, decimal cost, string snackType, Guid inventoryId, DateTimeOffset dateAdded, Guid id)
    {
        ValidateParams(label, price, cost, snackType);

        Label = new Descriptor(label);
        Price = new Currency(price);
        Cost = new Currency(cost);
        SnackType = new(snackType);
        InventoryId = new Identifier<Inventory>(inventoryId);
        DateAddedToInventory = dateAdded;
        Id = new Identifier<Snack>(id);

        static void ValidateParams(string label, decimal price, decimal cost, string snackType)
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
            if (string.IsNullOrWhiteSpace(snackType))
            {
                throw new ArgumentException($"Snack type {snackType} is invalid...", nameof(snackType));
            }
        }
    }

    internal Snack(string label, decimal price, decimal cost, string snackType, Guid inventoryId) : this(label, price, cost, snackType, inventoryId, DateTimeOffset.UtcNow, Guid.NewGuid()) { }
}
