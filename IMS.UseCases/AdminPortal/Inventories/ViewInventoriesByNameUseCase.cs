using IMS.CoreBusiness.Models;
using IMS.UseCases.AdminPortal.Inventories.Interfaces;
using IMS.UseCases.AdminPortal.Inventories.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Data is outside, so cannot be dependant on the repository layer/ data layer
// We need to use interface as an abstraction
namespace IMS.UseCases.AdminPortal.Inventories
{
    public class ViewProductsByNameUseCase : IViewInventoriesByNameUseCase
    {
        private readonly IInventoryRepository _inventoryRepository;
        public ViewProductsByNameUseCase(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;

        }
        public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
        {
            return await _inventoryRepository.GetInventoriesByNameAsync(name);
        }
    }
}
