using IMS.CoreBusiness.Models;

namespace IMS.UseCases.AdminPortal.Inventories.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<Inventory> ExecuteAsync(int inventoryId);
    }
}