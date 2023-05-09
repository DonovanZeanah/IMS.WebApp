using IMS.CoreBusiness.Models;

namespace IMS.UseCases.InventoryUseCases.Interfaces
{
    public interface IViewInventoriesByNameUseCase
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}