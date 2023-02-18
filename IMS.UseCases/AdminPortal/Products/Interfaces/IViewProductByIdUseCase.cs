using IMS.CoreBusiness.Models;

namespace IMS.UseCases.AdminPortal.Products.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<Inventory> ExecuteAsync(int productId);
    }
}