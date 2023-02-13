using IMS.CoreBusiness;
using IMS.UseCases.Inventories.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
  public class InventoryRepository : IInventoryRepository
  {
    private List<Inventory> _inventories;
    public InventoryRepository()
    {
      _inventories = new List<Inventory>()
      {
        new Inventory() { InventoryId = 1, InventoryName = "Tripod", Quantity = 10, Price = 30 },
        new Inventory() { InventoryId = 2, InventoryName = "Quickplate", Quantity = 100, Price = 20 },
        new Inventory() { InventoryId = 3, InventoryName = "Powerpole", Quantity = 100, Price = 12 },
        new Inventory() { InventoryId = 4, InventoryName = "Lensclothe", Quantity = 100, Price = 1 },
      };
    }
    public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name = "")
    {
      if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);
      return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
  }
}