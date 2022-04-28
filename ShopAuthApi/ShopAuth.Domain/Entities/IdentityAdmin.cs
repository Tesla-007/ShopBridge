using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAuth.Domain.Entities
{
    public enum AdminType
    {
        SuperAdmin, Admin
    }
    public class IdentityAdmin : IdentityUser
    {
       public AdminType AdminRole { get; set; }
    }
}
