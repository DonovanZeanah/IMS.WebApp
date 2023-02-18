using IMS.CoreBusiness.Models;

namespace IMS.UseCases.AdminPortal.Inventories.Interfaces
{
    public interface IEditProductUseCase
    {
        Task ExecuteAsync(Inventory inventory);

    }
}