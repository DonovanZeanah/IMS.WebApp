using IMS.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.UseCases.InventoryUseCases.Interfaces;

// Data is outside, so cannot be dependant on the repository layer/ data layer
// We need to use interface as an abstraction
namespace IMS.UseCases.InventoryUseCases
{
    public class ViewInventoriesByNameUseCase : IViewInventoriesByNameUseCase
    {
        private readonly ISQLiteInventoryRepository _inventoryRepository;
        public ViewInventoriesByNameUseCase(ISQLiteInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;

        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await _inventoryRepository.GetInventoriesByNameAsync(name);
        }
    }
}
