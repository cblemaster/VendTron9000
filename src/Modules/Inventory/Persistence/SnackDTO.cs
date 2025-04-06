
namespace Modules.Inventory.Persistence;

internal record SnackDTO(string Label, decimal Price, decimal Cost, int SnackTypeId, string MachineInventoryIndex, int InventoryId, DateTimeOffset DateAddedToMachineInventory, Guid Id);
