using Microsoft.AspNetCore.Mvc;
using Product.Domain.Interface;
using ShopBridgeProduct.ShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryDomain _categoryDomain;

        public CategoryController(ICategoryDomain categoryDomain)
        {
            _categoryDomain = categoryDomain;
        }

        [HttpPost("AddCaterory")]
        public async Task<IActionResult> AddCaterory([FromBody] CategoryModel category)
        {
            try
            {
                await _categoryDomain.AddCaterory(category.BindModel());
                return Ok("Catergory added Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int CatId)
        {
            try
            {
                await _categoryDomain.DeleteCategory(CatId);
                return Ok("Catergory deleted Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCategoryList")]
        public async Task<IActionResult> GetCategoryList()
        {
            try
            {
                return Ok(await _categoryDomain.GetCategoryList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
