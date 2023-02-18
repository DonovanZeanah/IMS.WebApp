using IMS.CoreBusiness.Models;
using IMS.UseCases.AdminPortal.Inventories.Interfaces;
using IMS.UseCases.AdminPortal.Inventories.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.AdminPortal.Inventories
{
    public class ViewProductByIdUseCase : IViewProductByIdUseCase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public ViewProductByIdUseCase(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task<Inventory> ExecuteAsync(int inventoryId)
        {
            return await _inventoryRepository.GetInventoryByIdAsync(inventoryId);
        }
    }
}
