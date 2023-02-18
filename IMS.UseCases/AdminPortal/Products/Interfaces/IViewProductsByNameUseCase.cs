using IMS.CoreBusiness.Models;

namespace IMS.UseCases.AdminPortal.Products.Interfaces
{
    public interface IViewProductsByNameUseCase
    {
        Task<IEnumerable<Product>> ExecuteAsync(string name = "");
    }
}