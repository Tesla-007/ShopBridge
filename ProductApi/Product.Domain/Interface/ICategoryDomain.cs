using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Interface
{
    public interface ICategoryDomain
    {
        Task<List<Category>> GetCategoryList();
        Task AddCaterory(Category category);
        Task DeleteCategory(int catId);
    }
}
