
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
    internal Descriptor MachineInventoryIndex { get; init; }
    internal Inventory Inventory { get; init; }
    internal Identifier<Inventory> InventoryId { get; init; }
    internal DateTimeOffset DateAddedToMachineInventory { get; init; }
    internal override Identifier<Snack> Id { get; init; }

    internal Snack(string label, decimal price, decimal cost, SnackType snackType, string index, Inventory inventory, DateTimeOffset dateAdded, Guid id)
    {
        ValidateParams(label, price, cost, snackType, index, inventory);

        Label = new Descriptor(label);
        Price = new Currency(price);
        Cost = new Currency(cost);
        SnackType = snackType;
        MachineInventoryIndex = new Descriptor(index);
        Inventory = inventory;
        InventoryId = inventory.Id;
        DateAddedToMachineInventory = dateAdded;
        Id = new Identifier<Snack>(id);

        static void ValidateParams(string label, decimal price, decimal cost, SnackType snackType, string index, Inventory inventory)
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
            if (snackType == SnackType.NotSet)
            {
                throw new ArgumentException($"{snackType} is invalid...", nameof(snackType));
            }
            if (string.IsNullOrWhiteSpace(index) || !Regex.Match(index, @"^[A-D][1-4]").Success)
            {
                throw new ArgumentException("Index is invalid...", nameof(index));
            }
            if (inventory is null)
            {
                throw new ArgumentNullException(nameof(inventory), "Inventory is required...");
            }
        }
    }

    internal Snack(string label, decimal price, decimal cost, SnackType snackType, string index, Inventory inventory) : this(label, price, cost, snackType, index, inventory, DateTimeOffset.UtcNow, Guid.NewGuid()) { }
}
