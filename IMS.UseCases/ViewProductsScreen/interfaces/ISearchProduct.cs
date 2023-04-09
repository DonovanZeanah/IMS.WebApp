using IMS.CoreBusiness.Models;

namespace IMS.UseCases.SearchProductScreen.interfaces
{
    public interface ISearchProduct
    {
      Product Execute(int id);
        IEnumerable<Product> Execute(string filter = null);
    }
}