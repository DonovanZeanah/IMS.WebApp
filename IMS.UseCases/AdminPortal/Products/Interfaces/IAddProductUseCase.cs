using IMS.CoreBusiness.Models;

namespace IMS.UseCases.AdminPortal.Products.Interfaces
{
    public interface IAddProductUseCase
    {
        Task ExecuteAsync(Product product);
    }
}