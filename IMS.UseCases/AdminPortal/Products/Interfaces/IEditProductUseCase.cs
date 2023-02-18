using IMS.CoreBusiness.Models;

namespace IMS.UseCases.AdminPortal.Products.Interfaces
{
    public interface IEditProductUseCase
    {
        Task ExecuteAsync(Product product);

    }
}