using Microsoft.AspNetCore.Mvc;
using Product.Domain.Entities;
using Product.Domain.Interface;
using Product.Domain.ProductDb;
using ShopBridgeProduct.ShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductDomain _productDomain;
        private readonly ProductDbContext _dbContext;

        public ProductController(IProductDomain productDomain, ProductDbContext dbContext)
        {
            _productDomain = productDomain;
            _dbContext = dbContext;
        }


        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel product)
        {
            try
            {
                var category = await _dbContext.Categories.FindAsync(product.CatId);
                if (category == null)
                {
                    throw new Exception("Please Provide a valid category");
                }
                ProductDetails productDetails = new()
                {
                    Price = product.Price,
                    Category = category,
                    ProductName = product.ProductName
                };
                await _productDomain.AddProduct(productDetails);
                return Ok("Product added Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int prodId)
        {
            try
            {
                await _productDomain.DeleteProduct(prodId);
                return Ok("Product deleted Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllProductsList")]
        public async Task<IActionResult> GetAllProductsList()
        {
            try
            {
                return Ok(await _productDomain.GetAllProductsList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductsListBasedOnCategory")]
        public async Task<IActionResult> GetProductsListBasedOnCategory(int catId)
        {
            try
            {
                return Ok(await _productDomain.GetProductsListBasedOnCategory(catId));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
