using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using BusinessObjects;
namespace Services
{
    public class ProductService : IProductService
    {
        private ProductRepository productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public bool Add(Product product)
        {
            return productRepository.Add(product);
        }

        public bool Delete(Product product)
        {
            return productRepository.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public List<Product> SearchByProductName(string productName)
        {
            return productRepository.SearchByProductName(productName);
        }

        public bool Update(Product product)
        {
            return productRepository.Update(product);
        }

        public void UpdateProductStock(int productID, short quantity)
        {
            productRepository.UpdateProductStock(productID, quantity);
        }
    }
}
