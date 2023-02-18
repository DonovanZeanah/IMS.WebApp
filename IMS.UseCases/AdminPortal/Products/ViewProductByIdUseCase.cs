using IMS.CoreBusiness.Models;
using IMS.CoreBusiness.PluginInterfaces.DataStore;
using IMS.UseCases.AdminPortal.Inventories.Interfaces;
using IMS.UseCases.Inventories.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.AdminPortal.Products
{
    public class ViewProductByIdUseCase : IViewProductByIdUseCase
    {
        private readonly IProductRepository _productRepository;

        public ViewProductByIdUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        Task<Inventory> IViewProductByIdUseCase.ExecuteAsync(int inventoryId)
        {
            throw new NotImplementedException();
        }
    }
}
