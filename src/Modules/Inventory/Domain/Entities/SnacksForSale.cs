namespace Modules.Inventory.Domain.Entities;

internal class SnacksForSale
{
    private const int MAX_COUNT_OF_SNACK = 5;

    internal IEnumerable<SnackLocation> SnackLocations { get; init; } = [];
}
