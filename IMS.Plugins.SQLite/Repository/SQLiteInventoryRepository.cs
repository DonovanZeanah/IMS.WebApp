using IMS.CoreBusiness.Models;
using IMS.Plugins.SQLite.Data;
using IMS.UseCases.InventoryUseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Plugins.SQLite
{
    public class SqliteInventoryRepository : ISQLiteInventoryRepository
    {
        private readonly IMSSQLiteDbContext _context;

        public SqliteInventoryRepository(IMSSQLiteDbContext context)
        {
            _context = context;
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            var lowerCaseInventoryName = inventory.InventoryName.ToLowerInvariant();

            var existingInventory =  _context.Inventories
     .AsEnumerable()
     .FirstOrDefault(i => i.InventoryName.ToLowerInvariant() == lowerCaseInventoryName);

            if (existingInventory == null)
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
            if (inventory == null)
                throw new ArgumentNullException(nameof(inventory));

            return await _context.Inventories.AnyAsync(x =>
                x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name = "")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return await _context.Inventories.ToListAsync();
            }

            return await _context.Inventories
                .Where(x => x.InventoryName.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
        {
            return await _context.Inventories
                .Include(i => i.InventorySources)
                .FirstOrDefaultAsync(i => i.InventoryId == inventoryId);
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            if (inventory == null)
                throw new ArgumentNullException(nameof(inventory));

            var existingInventory = await _context.Inventories
                .FirstOrDefaultAsync(i => i.InventoryId != inventory.InventoryId &&
                                          i.InventoryName.ToLowerInvariant() == inventory.InventoryName.ToLowerInvariant());

            if (existingInventory == null)
            {
                var inv = await _context.Inventories.FindAsync(inventory.Id);
                if (inv != null)
                {
                    inv.InventoryName = inventory.InventoryName;
                    inv.Price = inventory.Price;
                    inv.Quantity = inventory.Quantity;
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                throw new InvalidOperationException("Inventory with the same name already exists.");
            }
        }
    }
}


//using IMS.CoreBusiness.Models;
//using IMS.Plugins.SQLite.Data;
//using IMS.UseCases.InventoryUseCases.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace IMS.Plugins.SQLite
//{
//    public class SqliteInventoryRepository : ISQLiteInventoryRepository
//    {
//        private readonly IMSSQLiteDbContext _context;

//        public SqliteInventoryRepository(IMSSQLiteDbContext context)
//        {
//            _context = context;
//        }

//        public async Task AddInventoryAsync(Inventory inventory)
//        {
//            var lowerCaseInventoryName = inventory.InventoryName.ToLowerInvariant();

//            var existingInventory =  _context.Inventories
//    .AsEnumerable()
//    .FirstOrDefault(i => i.InventoryName.ToLowerInvariant() == lowerCaseInventoryName);

//            if (existingInventory == null)
//            {
//                _context.Inventories.Add(inventory);
//                await _context.SaveChangesAsync();
//            }
//            else
//            {
//                throw new InvalidOperationException("Inventory with the same name already exists.");
//            }
//        }


//        public async Task<bool> ExistsAsync(Inventory inventory)
//        {
//            if (inventory == null)
//                throw new ArgumentNullException(nameof(inventory));
//            return await _context.Inventories.AnyAsync(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase));
//        }

//        //public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name = "")
//        //{
//        //    if (string.IsNullOrWhiteSpace(name))
//        //    {
//        //        return await _context.Inventories.ToListAsync();
//        //    }

//        //    return await _context.Inventories
//        //        .Include(i => i.InventorySources)
//        //        .Where(x => EF.Functions.Like(x.InventoryName, $"%{name}%"))
//        //        .ToListAsync();
//        //}
//        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name = "")
//        {
//            if (string.IsNullOrWhiteSpace(name))
//            {
//                return await _context.Inventories.ToListAsync();
//            }

//            return await _context.Inventories
//                .Where(x => x.InventoryName.ToLower().Contains(name.ToLower()))
//                .ToListAsync();
//        }

//        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
//        {
//            return await _context.Inventories
//                .Include(i => i.InventorySources)
//                .FirstOrDefaultAsync(i => i.InventoryId == inventoryId);
//        }

//        public async Task UpdateInventoryAsync(Inventory inventory)
//        {
//            //if (inventory == null)
//            //    throw new ArgumentNullException(nameof(inventory));

//            //if (await _context.Inventories.AnyAsync(x => x.InventoryId != inventory.InventoryId && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
//            //{
//            //    throw new InvalidOperationException("Inventory with the same name already exists.");
//            //}

//            var inv = await _context.Inventories.FindAsync(inventory.Id);
//            if (inv != null)
//            {
//                inv.InventoryName = inventory.InventoryName;
//                inv.Price = inventory.Price;
//                inv.Quantity = inventory.Quantity;
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
//; []==============================[] =================================[]

//using IMS.CoreBusiness.Models;
//using IMS.Plugins.SQLite.Data;
//using IMS.UseCases.InventoryUseCases.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
///* 
// * the GetInventoriesByNameAsync and GetInventoryByIdAsync methods include an Include statement to eagerly load the associated Source entity. 
// * This allows you to access the source discriminator in the returned Inventory objects.

//Please make sure that the Inventory model includes a navigation property for the Source entity, such as public Source Source { get; set; }.
//Also, ensure that the IMSSQLiteDbContext is properly configured to include the necessary entity relationships.

//By including the Source entity, you can access the discriminator using inventory.Source.Discriminator in your Razor pages or other parts of the codebase.
//*/
//namespace IMS.Plugins.SQLite
//{
//    public class SqliteInventoryRepository : IInventoryRepository
//    {
//        private readonly IMSSQLiteDbContext _context;

//        public SqliteInventoryRepository(IMSSQLiteDbContext context)
//        {
//            _context = context;
//        }

//        public async Task AddInventoryAsync(Inventory inventory)
//        {
//            if (!await _context.Inventories.AnyAsync(i => i.InventoryName.ToLowerInvariant() == inventory.InventoryName.ToLowerInvariant()))
//            {
//                _context.Inventories.Add(inventory);
//                await _context.SaveChangesAsync();
//            }
//            else
//            {
//                throw new InvalidOperationException("Inventory with the same name already exists.");
//            }
//        }

//        public async Task<bool> ExistsAsync(Inventory inventory)
//        {
//            return await _context.Inventories.AnyAsync(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase));
//        }

//        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name = "")
//        {
//            if (string.IsNullOrWhiteSpace(name))
//            {
//                return await _context.Inventories.ToListAsync();
//            }

//            return await _context.Inventories
//                .Include(i => i.Source)
//                .Where(x => EF.Functions.Like(x.InventoryName, $"%{name}%"))
//                .ToListAsync();
//        }

//        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
//        {
//            return await _context.Inventories
//                .Include(i => i.Source)
//                .FirstOrDefaultAsync(i => i.InventoryId == inventoryId);
//        }

//        public async Task UpdateInventoryAsync(Inventory inventory)
//        {
//            if (await _context.Inventories.AnyAsync(x => x.InventoryId != inventory.InventoryId && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
//            {
//                throw new InvalidOperationException("Inventory with the same name already exists.");
//            }

//            var inv = await _context.Inventories.FindAsync(inventory.InventoryId);
//            if (inv != null)
//            {
//                inv.InventoryName = inventory.InventoryName;
//                inv.Price = inventory.Price;
//                inv.Quantity = inventory.Quantity;
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}


//using IMS.CoreBusiness.Models;
//using IMS.Plugins.SQLite.Data;
//using IMS.UseCases.InventoryUseCases.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace IMS.Plugins.SQLite
//{
//    public class SqliteInventoryRepository : IInventoryRepository
//    {
//        private readonly IMSSQLiteDbContext _context;

//        public SqliteInventoryRepository(IMSSQLiteDbContext context)
//        {
//            _context = context;
//        }

//        public async Task AddInventoryAsync(Inventory inventory)
//        {

//            if (!await _context.Inventories.AnyAsync(i => i.InventoryName.ToLowerInvariant() == inventory.InventoryName.ToLowerInvariant()))
//            {
//                _context.Inventories.Add(inventory);
//                await _context.SaveChangesAsync();
//            }
//            else
//            {
//                throw new InvalidOperationException("Inventory with the same name already exists.");
//            }
//        }


//        public async Task<bool> ExistsAsync(Inventory inventory)
//        {
//            return await _context.Inventories.AnyAsync(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase));
//        }

//        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name = "")
//        {
//            /*The GetInventoriesByNameAsync method will perform a case-insensitive search using the EF.Functions.Like method. 
//             * The percentage symbols % around the name parameter are used as wildcards 
//             * to match any sequence of characters before or after the name.*/
//            if (string.IsNullOrWhiteSpace(name))
//            {
//                return await _context.Inventories.ToListAsync();
//            }

//            return await _context.Inventories
//                .Where(x => EF.Functions.Like(x.InventoryName, $"%{name}%"))
//                .ToListAsync();
//        }


//        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
//        {
//            return await _context.Inventories.FindAsync(inventoryId);
//        }

//        public async Task UpdateInventoryAsync(Inventory inventory)
//        {
//            //prevent duplicate inventory names
//            if (await _context.Inventories.AnyAsync(x => x.InventoryId != inventory.InventoryId && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
//                return;

//            var inv = await _context.Inventories.FindAsync(inventory.InventoryId);
//            if (inv != null)
//            {
//                inv.InventoryName = inventory.InventoryName;
//                inv.Price = inventory.Price;
//                inv.Quantity = inventory.Quantity;
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
