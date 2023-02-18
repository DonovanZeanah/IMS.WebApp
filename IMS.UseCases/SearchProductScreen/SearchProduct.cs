using IMS.CoreBusiness.Models;
using IMS.CoreBusiness.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.SearchProductScreen
{
  public class SearchProduct
  {
    private readonly IProductRepository productRepository;

    public SearchProduct(IProductRepository productRepository)
    {
      this.productRepository = productRepository;
    }
    
    public IEnumerable<Product> Execute(string filter)
    { 
      return productRepository.GetProducts(filter);
    
    }
  }
}
