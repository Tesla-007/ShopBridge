

using ShopAuth.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAuth.Domain.Interface
{
    public interface IAccountDomain
    {
        Task CreateNewRequest(NewAdminRequest newRequest);

        Task ChangeRequestStatus(int reqId, Approval approval, string userId, string Reason);
        Task<List<NewAdminRequest>> ViewPendingStatus(string userId, int limit);
    }
}
