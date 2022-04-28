using Microsoft.AspNetCore.Identity;
using ShopAuth.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ShopAuth.ShopAuthModels
{
    public class AdminSignUpCredsModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [MinLength(5)]
        public string Password { get; set; }

        [MinLength(5)]
        public string ConfirmPassword { get; set; }

        public IdentityAdmin BindModel()
        {
            IdentityAdmin usr = new();
            usr.UserName = UserName;
            usr.Email = Email;
            usr.AdminRole = AdminType.Admin;
            return usr;
        }
    }
}
