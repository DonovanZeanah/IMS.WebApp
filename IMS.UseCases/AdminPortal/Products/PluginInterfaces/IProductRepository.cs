using IMS.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.AdminPortal.Products.PluginInterfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name = "");
        Task<bool> ExistsAsync(Product product);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int productId);

    }
}
