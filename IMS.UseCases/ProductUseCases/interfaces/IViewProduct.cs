using IMS.CoreBusiness.Models;

namespace IMS.UseCases.SearchProductScreen.interfaces
{
    public interface IViewProduct
    {
        Product Execute(int id);
    }
}