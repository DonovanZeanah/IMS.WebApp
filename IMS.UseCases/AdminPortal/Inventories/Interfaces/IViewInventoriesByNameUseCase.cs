using IMS.CoreBusiness.Models;

namespace IMS.UseCases.AdminPortal.Inventories.Interfaces
{
    public interface IViewInventoriesByNameUseCase
    {
        Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
    }
}