using IMS.CoreBusiness.Models;
using IMS.UseCases.PluginInterfaces.DataStore;

namespace IMS.plugins.DataStore.HardCoded
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products; // = new List<Product>()

        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product() { Id = 1, Brand = "Cobalt", Name = "Product 1", Description = "Product 1 Description", Price = 1.00 },
                new Product() { Id = 2, Brand = "Cobalt", Name = "Product 2", Description = "Product 2 Description", Price = 2.00 },
                new Product() { Id = 3, Brand = "Cobalt", Name = "Product 3", Description = "Product 3 Description", Price = 3.00 },
                new Product() { Id = 4, Brand = "Cobalt", Name = "Product 4", Description = "Product 4 Description", Price = 4.00 },
                new Product() { Id = 5, Brand = "Cobalt", Name = "Product 5", Description = "Product 5 Description", Price = 5.00 },
                new Product() { Id = 6, Brand = "Cobalt", Name = "Product 6", Description = "Product 6 Description", Price = 6.00 },
                new Product() { Id = 7, Brand = "Cobalt", Name = "Product 7", Description = "Product 7 Description", Price = 7.00 },
                new Product() { Id = 8, Brand = "Cobalt", Name = "Product 8", Description = "Product 8 Description", Price = 8.00 },
                new Product() { Id = 9, Brand = "Cobalt", Name = "Product 9", Description = "Product 9 Description", Price = 9.00 },
                new Product() { Id = 10, Brand = "Cobalt", Name = "Product 10", Description = "Product 10 Description", Price = 10.00 },
                new Product() { Id = 11, Brand = "Cobalt", Name = "Product 11", Description = "Product 11 Description", Price = 11.00 },
                new Product() { Id = 12, Brand = "Cobalt", Name = "Product 12", Description = "Product 12 Description", Price = 12.00 },
                new Product() { Id = 13, Brand = "Cobalt", Name = "Product 13", Description = "Product 13 Description", Price = 13.00 },
                new Product() { Id = 14, Brand = "Cobalt", Name = "Product 14", Description = "Product 14 Description", Price = 14.00 },
                new Product() { Id = 15, Brand = "Cobalt", Name = "Product 15", Description = "Product 15 Description", Price = 20.00 }
            };

        }


        public Product GetProduct(int id)
        {
           return _products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProducts(string filter = null)
        {
            if (string.IsNullOrEmpty(filter)) return _products;

            return _products.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }
    }
}