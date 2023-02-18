using IMS.CoreBusiness.Models;

namespace IMS.UseCases.AdminPortal.Inventories.Interfaces
{
    public interface IAddInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}