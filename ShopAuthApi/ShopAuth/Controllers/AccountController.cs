using Microsoft.AspNetCore.Mvc;
using ShopAuth.Domain.Interface;
using ShopAuth.IdenityService;
using ShopAuth.ShopAuthModels;
using System;
using System.Threading.Tasks;

namespace ShopAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IShopAuthIdenity shopAuthIdenity;
        private readonly IAccountDomain accountDomain;

        public AccountController(IShopAuthIdenity shopAuthIdenity, IAccountDomain accountDomain)
        {
            this.shopAuthIdenity = shopAuthIdenity;
            this.accountDomain = accountDomain;
        }

        [HttpPost("AdminSignIn")]
        public async Task<IActionResult> SignIn([FromBody] AdminSignInCredsModel user)
        {
            try
            {
                var token = await shopAuthIdenity.AdminSignInAsync(user);
                return Ok(new { 
                    Token = token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AdminSignUp")]
        public async Task<IActionResult> SignUp([FromBody] AdminSignUpCredsModel newUser)
        {
            try
            {
                await shopAuthIdenity.SignUpAsync(newUser);
                return Ok("Account Created");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateNewRequest")]
        public async Task<IActionResult> CreateNewRequest([FromBody] NewUserRequestModel requestData)
        {
            try
            {
                await accountDomain.CreateNewRequest(requestData.BindModel());
                return Ok("New Request Created, Please Contact admin for approval!!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
