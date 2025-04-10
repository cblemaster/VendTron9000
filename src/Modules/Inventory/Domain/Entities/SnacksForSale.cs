
using System.Text.Json;

namespace Modules.Inventory.Domain.Entities;

internal class SnacksForSale
{
    private const int MAX_COUNT_OF_SNACK = 5;

    internal IEnumerable<SnackLocation> SnackLocations { get; init; } = [];

    //internal SnacksForSale() => Id = new Identifier<SnacksForSale>();

    //private static List<Snack> SnackInventory() =>
    //    [
    //        new("Potato Crisps", 3.05m, 2.70m, "Chips", "A1"),
    //        new("Prongles", 1.45m, 1.25m, "Chips", "A2"),
    //        new("Boogles", 2.75m, 2.40m, "Chips", "A3"),
    //        new("Veggie Crisps", 3.65m, 2.95m, "Chips", "A4"),

    //        new("Lieutenants Wafers", 1.80m, 1.50m, "Crackers", "B1"),
    //        new("Chweesits", 1.50m, 1.05m, "Crackers", "B2"),
    //        new("Pita Squares", 1.50m, 1.25m, "Crackers", "B3"),
    //        new("Nyblets", 1.75m, 1.35m, "Crackers", "B4"),

    //        new("Cola", 1.25m, 1.00m, "Drink", "C1"),
    //        new("Dr. Rumble", 1.50m, 1.25m, "Drink", "C2"),
    //        new("Mountain Condensate", 1.50m, 1.15m, "Drink", "C3"),
    //        new("EnergyStroke", 1.50m, 1.00m, "Drink", "C4"),

    //        new("Cinnamon Pastry", 0.85m, 0.70m, "Pastry", "D1"),
    //        new("Strawberry Pastry", 0.95m, 0.80m, "Pastry", "D2"),
    //        new("Blueberry Pastry", 0.75m, 0.65m, "Pastry", "D3"),
    //        new("Apple Pastry", 0.75m, 0.60m, "Pastry", "D4"),
    //    ];
}
