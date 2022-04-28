using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Interface
{
    public interface IProductDomain
    {
        Task<List<ProductDetails>> GetAllProductsList();

        Task<List<ProductDetails>> GetProductsListBasedOnCategory(int CategoryId);

        Task AddProduct(ProductDetails productDetails);

        Task DeleteProduct(int prodId);
    }
}
