using Microsoft.AspNetCore.Identity;
using ShopAuth.Domain.Entities;
using ShopAuth.Domain.ShopBridgeDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAuth.Domain.SeedData
{
    public static class SeedSuperAdmin
    {
        public static IdentityRole AddRole()
        {

            var superRole = new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR".ToUpper()
            };
            return superRole;
        }
        public static List<IdentityAdmin> AddData()
        {

            var superAdmins = new List<IdentityAdmin>()
            {
                new IdentityAdmin() 
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "test109",
                    Email = "test109@gmail.com",
                    NormalizedUserName = "TEST109",
                    LockoutEnabled = false,
                    AdminRole = AdminType.SuperAdmin,
                    PasswordHash = new PasswordHasher<IdentityAdmin>().HashPassword(null, "Test@109")
                }
            };
            return superAdmins;
        }
    
        public static IdentityUserRole<string> LinkSuperAdminAndRole()
        {
            var res = new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            };
            return res;

        }
    }
}
