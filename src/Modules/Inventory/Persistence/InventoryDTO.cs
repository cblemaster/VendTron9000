
namespace Modules.Inventory.Persistence;

internal record InventoryDTO(IEnumerable<SnackDTO> Snacks, int InventoryTypeId, Guid Id);
