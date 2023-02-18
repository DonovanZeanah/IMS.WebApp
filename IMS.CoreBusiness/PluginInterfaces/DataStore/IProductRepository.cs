using IMS.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.PluginInterfaces.DataStore
{
  public interface IProductRepository
  {
    Product GetProduct(int id);
    IEnumerable<Product> GetProducts(string filter = null);

  }
}
