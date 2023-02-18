using IMS.CoreBusiness.Models;
using IMS.UseCases.AdminPortal.Products.Interfaces;
using IMS.UseCases.AdminPortal.Products.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.AdminPortal.Products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public AddProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task ExecuteAsync(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }


    }
}
