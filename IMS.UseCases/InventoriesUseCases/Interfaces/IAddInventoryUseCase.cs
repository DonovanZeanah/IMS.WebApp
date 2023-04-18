using IMS.CoreBusiness.Models;

namespace IMS.UseCases.InventoryUseCases.Interfaces
{
    public interface IAddInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}