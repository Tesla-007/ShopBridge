using Product.Domain.Entities;
using Product.Domain.Interface;
using Product.Domain.ProductDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeProduct.Domain
{
    public class CategoryDomain : ICategoryDomain
    {
        private readonly ProductDbContext _dbContext;

        public CategoryDomain(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        } 
        public async Task AddCaterory(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(int catId)
        {
            var catergory = await _dbContext.Categories.FindAsync(catId);
            if(catergory == null)
            {
                throw new Exception("Category Not Found");
            }
           
            var prodList = await Task.Run(() =>
            {
                return _dbContext.Products.Where(x => x.Category == catergory);
            });
            _dbContext.Products.RemoveRange(prodList);
            _dbContext.Categories.Remove(catergory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategoryList()
        {
            var catergoryList = await Task.Run(() =>
            {
                return _dbContext.Categories.ToList();
            });
            return catergoryList;
        }

        
    }
}
