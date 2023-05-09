using IMS.CoreBusiness.Models;
using IMS.UseCases.InventoryUseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.SQLite
{
    public class SqliteInventoryRepository : IInventoryRepository
    {
        private readonly IMSSQLiteDbContext _context;

        public SqliteInventoryRepository(IMSSQLiteDbContext context)
        {
            _context = context;
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            /*The GetInventoriesByNameAsync method will perform a case-insensitive search using the EF.Functions.Like method. 
             * The percentage symbols % around the name parameter are used as wildcards 
             * to match any sequence of characters before or after the name.*/
            if (!await _context.Inventories.AnyAsync(i => i.InventoryName.ToLowerInvariant() == inventory.InventoryName.ToLowerInvariant()))
            {
                _context.Inventories.Add(inventory);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Inventory with the same name already exists.");
            }
        }


        public async Task<bool> ExistsAsync(Inventory inventory)
        {
            return await _context.Inventories.AnyAsync(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name = "")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return await _context.Inventories.ToListAsync();
            }

            return await _context.Inventories
                .Where(x => EF.Functions.Like(x.InventoryName, $"%{name}%"))
                .ToListAsync();
        }


        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
        {
            return await _context.Inventories.FindAsync(inventoryId);
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            //prevent duplicate inventory names
            if (await _context.Inventories.AnyAsync(x => x.InventoryId != inventory.InventoryId && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
                return;

            var inv = await _context.Inventories.FindAsync(inventory.InventoryId);
            if (inv != null)
            {
                inv.InventoryName = inventory.InventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
                await _context.SaveChangesAsync();
            }
        }
    }
}
