using IMS.CoreBusiness.Models;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IEditInventoryUseCase
    {
    Task ExecuteAsync(Inventory inventory);

  }
}