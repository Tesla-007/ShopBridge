using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAuth.Domain;
using ShopAuth.ShopAuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopAuth.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly HttpClient _http;

        public ProductController(HttpClient http) {
            _http = http;
        }

        [HttpGet("GetAllProductsList")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProductsList()
        {
            try
            {
                var res = await _http.GetAsync("http://localhost:5002/api/Product/GetAllProductsList");
                var responseMsg = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode)
                {
                    return Ok(responseMsg);
                }
                else
                {
                    return BadRequest(responseMsg);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetProductsListBasedOnCategory/{catId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductsListBasedOnCategory(int catId)
        {
            try
            {
                var res = await _http.GetAsync("http://localhost:5002/api/Product/GetProductsListBasedOnCategory?catId=" + catId);
                var responseMsg = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode)
                {
                    return Ok(responseMsg);
                }
                else
                {
                    return BadRequest(responseMsg);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel product)
        {
            try
            {
                var res = await _http.SendAsync(product.BindModel());
                var responseMsg = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode)
                {
                    return Ok(responseMsg);
                }
                else
                {
                    return BadRequest(responseMsg);
                }

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
                var res = await _http.PostAsync("http://localhost:5002/api/Product/DeleteProduct?prodId=" + prodId, null);
                var responseMsg = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode)
                {
                    return Ok(responseMsg);
                }
                else
                {
                    return BadRequest(responseMsg);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
