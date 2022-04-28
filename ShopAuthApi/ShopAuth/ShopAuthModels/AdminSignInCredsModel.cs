using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAuth.ShopAuthModels
{
    public class AdminSignInCredsModel
    {
        [Required]
        public string UserName { get; set; }
        [MinLength(5)]
        public string Password { get; set; }
    }
}
