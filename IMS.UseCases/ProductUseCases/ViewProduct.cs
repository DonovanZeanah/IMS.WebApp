using IMS.CoreBusiness.Models;
using IMS.UseCases.SearchProductScreen.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.UseCases.PluginInterfaces.DataStore;

namespace IMS.UseCases.SearchProductScreen
{
    public class ViewProduct : IViewProduct
  {
    private readonly IProductRepository _productRepository;

    public ViewProduct(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }
    public Product Execute(int id)
    {
      return _productRepository.GetProduct(id);
    }
  }
}
