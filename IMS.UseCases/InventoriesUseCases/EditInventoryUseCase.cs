using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models;
using IMS.UseCases.InventoryUseCases.Interfaces;

namespace IMS.UseCases.InventoryUseCases
{
    public class EditInventoryUseCase : IEditInventoryUseCase
    {
        private readonly ISQLiteInventoryRepository _inventoryRepository;
        public EditInventoryUseCase(ISQLiteInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task ExecuteAsync(Inventory inventory)
        {
            await _inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
