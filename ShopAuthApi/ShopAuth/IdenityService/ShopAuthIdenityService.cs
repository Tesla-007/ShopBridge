using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopAuth.Domain.Entities;
using ShopAuth.Domain.ShopBridgeDb;
using ShopAuth.ShopAuthModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopAuth.IdenityService
{
    public class ShopAuthIdenityService : IShopAuthIdenity
    {
        private readonly UserManager<IdentityAdmin> userManager;
        private readonly SignInManager<IdentityAdmin> signInManager;
        private readonly ShopBridgeDbContext dbContext;

        public ShopAuthIdenityService(UserManager<IdentityAdmin> userManager, 
                                      SignInManager<IdentityAdmin> signInManager, 
                                      ShopBridgeDbContext dbContext, 
                                      IConfiguration configuartion)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dbContext = dbContext;
            Configuartion = configuartion;
        }

        public IConfiguration Configuartion { get; }

        public async Task<string> AdminSignInAsync(AdminSignInCredsModel adminCreds)
        {
           
            try
            {
                var user = await userManager.FindByNameAsync(adminCreds.UserName);
                var isCredsValid = await signInManager.PasswordSignInAsync(user, adminCreds.Password, false, false);

                if (!isCredsValid.Succeeded)
                {
                    throw new Exception("Invalid Credentials");
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Configuartion["Tokens:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                         new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                         new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var rawToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(rawToken);
                return token;

            }
            catch
            {
                throw new Exception("Error while signing in. Please contact adminstrator!!");
            }

        }

        public async Task SignUpAsync(AdminSignUpCredsModel newUser)
        {
            var admin = dbContext.NewAdminRequests.FirstOrDefault(x => x.Email == newUser.Email);
            if (admin == null)
            {
                throw new Exception("No such request in queue!!");
            }
            else if (admin.ApprovalStatus == Approval.Denied)
            {
                throw new Exception("Request has been denied");
            }
            else if (admin.ApprovalStatus == Approval.Pending)
            {
                throw new Exception("Request is pending for approval. Please contact your manager to gain access!!");
            }
            else
            {
                var isExist = await userManager.FindByNameAsync(newUser.UserName);
                if (isExist != null)
                {
                    throw new Exception("Username already exists");
                }
            }

            await userManager.CreateAsync(newUser.BindModel(), newUser.Password);
        }
    }
}
