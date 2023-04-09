using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models;
using IMS.UseCases.Inventories.Interfaces;

namespace IMS.UseCases.Inventories
{
    public class EditInventoryUseCase : IEditInventoryUseCase
  {
    private readonly IInventoryRepository _inventoryRepository;
    public EditInventoryUseCase(IInventoryRepository inventoryRepository)
    {
      _inventoryRepository = inventoryRepository;
    }

    public async Task ExecuteAsync(Inventory inventory)
    {
      await _inventoryRepository.UpdateInventoryAsync(inventory);
    }
  }
}
