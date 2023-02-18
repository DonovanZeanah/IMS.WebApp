using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models;
using IMS.UseCases.AdminPortal.Inventories.Interfaces;
using IMS.UseCases.AdminPortal.Inventories.PluginInterfaces;

namespace IMS.UseCases.AdminPortal.Inventories
{
    public class EditIProductUseCase : IEditProductUseCase
    {
        private readonly IInventoryRepository _inventoryRepository;
        public EditIProductUseCase(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(Inventory inventory)
        {
            await _inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
