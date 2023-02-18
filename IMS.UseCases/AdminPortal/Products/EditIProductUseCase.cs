using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models;
using IMS.UseCases.AdminPortal.Products.Interfaces;
using IMS.UseCases.AdminPortal.Products.PluginInterfaces;

namespace IMS.UseCases.AdminPortal.Products
{
    public class EditIProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository _productRepository;
        public EditIProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ExecuteAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }


    }
}
