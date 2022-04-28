using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShopAuth.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly HttpClient _http;

        public CategoryController(HttpClient http)
        {
            _http = http;
        }

        [HttpGet("GetCategoryList")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategoryList()
        {
            try
            {
                var res = await _http.GetAsync("http://localhost:5002/api/Category/GetCategoryList");
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


        [HttpPost("AddCaterory")]
        public async Task<IActionResult> AddCaterory(string CategoryName)
        {
            try
            {
               
                HttpContent httpContent = JsonContent.Create(new {
                    Name = CategoryName
                });
                var res = await _http.PostAsync("http://localhost:5002/api/Category/AddCaterory", httpContent);
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

        [HttpPost("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int CatId)
        {
            try
            {
                var res = await _http.PostAsync("http://localhost:5002/api/Category/DeleteCategory?CatId=" + CatId, null);
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
