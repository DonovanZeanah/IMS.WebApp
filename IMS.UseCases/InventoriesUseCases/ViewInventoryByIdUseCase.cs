using IMS.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.UseCases.InventoryUseCases.Interfaces;

namespace IMS.UseCases.InventoryUseCases
{
    public class ViewInventoryByIdUseCase : IViewInventoryByIdUseCase
    {
        private readonly ISQLiteInventoryRepository _inventoryRepository;

        public ViewInventoryByIdUseCase(ISQLiteInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task<Inventory> ExecuteAsync(int inventoryId)
        {
            return await _inventoryRepository.GetInventoryByIdAsync(inventoryId);
        }
    }
}
