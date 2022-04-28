using Product.Domain.Entities;
using Product.Domain.Interface;
using Product.Domain.ProductDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeProduct.Domain
{
    public class ProductDomain : IProductDomain
    {
        private readonly ProductDbContext _dbContext;

        public ProductDomain(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddProduct(ProductDetails productDetails)
        {
            await _dbContext.Products.AddAsync(productDetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int prodId)
        {
            var product = await _dbContext.Products.FindAsync(prodId);
            if (product == null)
            {
                throw new Exception("Category Not Found");
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProductDetails>> GetAllProductsList()
        {
            var productList = await Task.Run(() =>
            {
                return _dbContext.Products.ToList();
            });
            return productList;
        }

        public async Task<List<ProductDetails>> GetProductsListBasedOnCategory(int CategoryId)
        {
            var productList = await Task.Run(() =>
            {
                return _dbContext.Products.Where(x => x.Category.Id == CategoryId).ToList();
            });
            return productList;
        }

    }
}
