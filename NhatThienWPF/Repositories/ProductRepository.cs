using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private LucySalesDbContext dbContext;
        public ProductRepository()
        {
            dbContext = new LucySalesDbContext();
        }

        public bool Add(Product product)
        {
            dbContext.Products.Add(product);
            if( dbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(Product product)
        {
            Product existingProduct = dbContext.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (existingProduct != null)
            {
                existingProduct.Discontinued = true;
            }

            if( dbContext.SaveChanges() > 0 ) { return true; }
            return false;
        }

        public List<Product> GetAllProducts()
        {
            return dbContext.Products.ToList();
        }

        public List<Product> SearchByProductName(string productName)
        {
            return dbContext.Products.Where(p => p.ProductName.Contains(productName)).ToList();
        }

        public bool Update(Product product)
        {
            Product existingProduct = dbContext.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.CategoryID = product.CategoryID;
                existingProduct.QuantityPerUnit = product.QuantityPerUnit;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.UnitsInStock = product.UnitsInStock;
            }

            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public void UpdateProductStock(int productID, short quantity)
        {
            var product = dbContext.Products.Find(productID);
            if (product != null)
            {
                if(product.UnitsInStock >= quantity)
                {
                    product.UnitsInStock -= quantity;
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException($"Insufficient stock for product {product.ProductName}. Only {product.UnitsInStock} item(s) remaining.");
                }
            }
            else
            {
                throw new ArgumentException($"Product with ID {productID} was not found.");
            }
        }
    }
}
