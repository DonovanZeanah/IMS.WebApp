using IMS.CoreBusiness.Models;

namespace IMS.UseCases.InventoryUseCases.Interfaces
{
    public interface IEditInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);

    }
}