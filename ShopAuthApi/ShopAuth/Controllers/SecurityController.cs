using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAuth.Domain.Entities;
using ShopAuth.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAuth.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class SecurityController : Controller
    {
       private readonly IAccountDomain accountDomain;

        public SecurityController(IAccountDomain accountDomain)
        {
           this.accountDomain = accountDomain;
        }

        [HttpPost("ChangeRequestStatus")]
        public async Task<IActionResult> ChangeRequestStatus(int reqId, string userId, string Reason, Approval approval)
        {
            try
            {
                await accountDomain.ChangeRequestStatus(reqId, approval, userId, Reason);
                return Ok("Account Created");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ViewPendingStatus")]
        public async Task<IActionResult> ViewPendingStatus(string userId, int limit)
        {
            try
            {
                return Ok(await accountDomain.ViewPendingStatus(userId, limit));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
