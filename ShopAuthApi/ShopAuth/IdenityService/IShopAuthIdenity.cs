using ShopAuth.ShopAuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAuth.IdenityService
{
    public interface IShopAuthIdenity
    {
        Task SignUpAsync(AdminSignUpCredsModel newUser);

        Task<string> AdminSignInAsync(AdminSignInCredsModel adminCreds);
    }
}
