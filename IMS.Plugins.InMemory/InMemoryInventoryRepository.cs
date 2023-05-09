using IMS.CoreBusiness.Models;
using IMS.UseCases.InventoryUseCases.Interfaces;

namespace IMS.Plugins.InMemory
{
    public class InMemoryInventoryRepository : IInventoryRepository
    {
        private List<Inventory> inventories;
        public InMemoryInventoryRepository()
        {
            inventories = new List<Inventory>()
      {
        new Inventory() { InventoryId = 1, InventoryName = "Steering Wheel", Quantity = 10, Price = 30 },
        new Inventory() { InventoryId = 2, InventoryName = "Brake Pad", Quantity = 20, Price = 15 }       ,
        new Inventory() { InventoryId = 3, InventoryName = "Air Filter", Quantity = 50, Price = 5 }       ,
        new Inventory() { InventoryId = 4, InventoryName = "Spark Plug", Quantity = 100, Price = 2 }      ,
        new Inventory() { InventoryId = 5, InventoryName = "Oil Filter", Quantity = 30, Price = 10 }      ,
        new Inventory() { InventoryId = 6, InventoryName = "Tire", Quantity = 15, Price = 50 }            ,
        new Inventory() { InventoryId = 7, InventoryName = "Battery", Quantity = 5, Price = 100 }         ,
        new Inventory() { InventoryId = 8, InventoryName = "Wiper Blade", Quantity = 25, Price = 7 }      ,
        new Inventory() { InventoryId = 9, InventoryName = "Alternator", Quantity = 2, Price = 150 }      ,
        new Inventory() { InventoryId = 10, InventoryName = "Radiator", Quantity = 3, Price = 80 }        ,
        new Inventory() { InventoryId = 11, InventoryName = "Shock Absorber", Quantity = 8, Price = 40 }  ,
        new Inventory() { InventoryId = 12, InventoryName = "Fuel Filter", Quantity = 20, Price = 12 }    ,
        new Inventory() { InventoryId = 13, InventoryName = "Serpentine Belt", Quantity = 12, Price = 18 },
        new Inventory() { InventoryId = 14, InventoryName = "Water Pump", Quantity = 5, Price = 75 }      ,
        new Inventory() { InventoryId = 15, InventoryName = "Starter Motor", Quantity = 3, Price = 120 }  ,
        new Inventory() { InventoryId = 16, InventoryName = "Brake Rotor", Quantity = 6, Price = 60 }     ,
        new Inventory() { InventoryId = 17, InventoryName = "Timing Belt", Quantity = 8, Price = 25 }     ,
        new Inventory() { InventoryId = 18, InventoryName = "Headlight Bulb", Quantity = 30, Price = 5 }  ,
        new Inventory() { InventoryId = 19, InventoryName = "Exhaust Pipe", Quantity = 4, Price = 90 }    ,
        new Inventory() { InventoryId = 20, InventoryName = "Oxygen Sensor", Quantity = 5, Price = 50 }   ,
        new Inventory() { InventoryId = 21, InventoryName = "Steering Wheel", Quantity = 10, Price = 30 },
        new Inventory() { InventoryId = 22, InventoryName = "Driver Seat", Quantity = 100, Price = 20 },
        new Inventory() { InventoryId = 23, InventoryName = "Battery Bank", Quantity = 100, Price = 12 },
        new Inventory() { InventoryId = 24, InventoryName = "Drive Motor", Quantity = 100, Price = 1 }
      };
        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            var maxId = inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId + 1;
            inventories.Add(inventory);
            return Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(Inventory inventory)
        {
            return await Task.FromResult(inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name = "")
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(inventories);
            return inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
        {
            var inv = inventories.FirstOrDefault(x => x.InventoryId == inventoryId);
            var newInv = new Inventory
            {
                InventoryId = inventoryId,
                InventoryName = inv.InventoryName,
                Price = inv.Price,
                Quantity = inv.Quantity
            };
            return await Task.FromResult(newInv);
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            //prevent duplicate inventory names
            if (inventories.Any(x => x.InventoryId != inventory.InventoryId && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var inv = inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
            }
            return Task.CompletedTask;
        }
    }
}