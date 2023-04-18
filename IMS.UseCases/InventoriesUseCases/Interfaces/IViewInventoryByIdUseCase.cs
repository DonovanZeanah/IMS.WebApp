using IMS.CoreBusiness.Models;

namespace IMS.UseCases.InventoryUseCases.Interfaces
{
    public interface IViewInventoryByIdUseCase
    {
        Task<Inventory> ExecuteAsync(int inventoryId);
    }
}