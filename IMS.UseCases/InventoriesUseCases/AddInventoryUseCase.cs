using IMS.CoreBusiness.Models;
using IMS.UseCases._PluginInterfaces_.DataStore;
using IMS.UseCases.InventoriesUseCases.Interfaces;
using IMS.UseCases.InventoryUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.InventoryUseCases
{
    public class AddInventoryUseCase : IAddInventoryUseCase
    {
        private readonly ISQLiteInventoryRepository _SQLiteInventoryRepository;
        private readonly ISQLiteBaseSourceRepository _SQLiteBaseSourceRepository;

        public AddInventoryUseCase()
        {
        }
        public AddInventoryUseCase(ISQLiteInventoryRepository SQLiteInventoryRepository, ISQLiteBaseSourceRepository SQLiteBaseSourceRepository)
        {
            _SQLiteInventoryRepository = SQLiteInventoryRepository;
            _SQLiteBaseSourceRepository = SQLiteBaseSourceRepository;
        }
        public async Task ExecuteAsync(Inventory inventory)
        {
            Console.WriteLine($"Executing ExecuteAsync for inventory with ID: {inventory.Id}");

            var sources = await _SQLiteBaseSourceRepository.GetAllSourcesAsync();
            Console.WriteLine($"Retrieved {sources.Count} sources from the repository");

            var inventorySources = new List<InventorySource>();
            foreach (var inventorySource in inventory.InventorySources)
            {
                Console.WriteLine($"Processing inventory source: {inventorySource}");

                var source = sources.FirstOrDefault(s => s.Id == inventorySource.SourceId);
                if (source == null)
                {
                    Console.WriteLine($"Invalid source with ID {inventorySource.SourceId} selected.");
                    throw new InvalidOperationException($"Invalid source with ID {inventorySource.SourceId} selected.");
                }

                Console.WriteLine($"Found matching source: {source.Name}");

                inventorySources.Add(new InventorySource { InventoryId = inventory.Id, SourceId = source.Id });
                Console.WriteLine($"Added inventory source: {inventorySource.SourceId}");
            }

            // Create a new inventory object instead of modifying the existing one
            var newInventory = new Inventory
            {
                InventoryName = inventory.InventoryName,
                Quantity = inventory.Quantity,
                Price = inventory.Price,
                InventorySources = inventorySources
            };

            Console.WriteLine("Adding new inventory to the repository");
            await _SQLiteInventoryRepository.AddInventoryAsync(newInventory);
            Console.WriteLine("Inventory added successfully");
        }

        public async Task<ICollection<Source>> GetAllSourcesAsync()
        {
            Console.WriteLine("Executing GetAllSourcesAsync");

            var sources = await _SQLiteBaseSourceRepository.GetAllSourcesAsync();

            Console.WriteLine($"Retrieved {sources.Count} sources from the repository");
            return sources;
        }

    }
}
