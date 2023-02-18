using IMS.CoreBusiness.Models;
using IMS.UseCases.AdminPortal.Products.Interfaces;
using IMS.UseCases.AdminPortal.Products.PluginInterfaces;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.Inventories.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Data is outside, so cannot be dependant on the repository layer/ data layer
// We need to use interface as an abstraction
namespace IMS.UseCases.AdminPortal.Products
{
    public class ViewProductsByNameUseCase : IViewProductsByNameUseCase
    {
        private readonly IProductRepository _productRepository;
        public ViewProductsByNameUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }


        Task<IEnumerable<Product>> IViewProductsByNameUseCase.ExecuteAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
