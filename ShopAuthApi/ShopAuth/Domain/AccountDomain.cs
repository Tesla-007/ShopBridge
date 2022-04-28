using ShopAuth.Domain.Entities;
using ShopAuth.Domain.Interface;
using System.Threading.Tasks;
using ShopAuth.Domain.ShopBridgeDb;
using ShopAuth.IdenityService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopAuth
{
    public class AccountDomain : IAccountDomain
    {
        private readonly ShopBridgeDbContext _dbContext;
        private readonly UserManager<IdentityAdmin> _userManager;

        public AccountDomain(ShopBridgeDbContext dbContext, UserManager<IdentityAdmin> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task ChangeRequestStatus(int reqId, Approval approval, string userId, string Reason)
        {
            var admin = await _userManager.FindByIdAsync(userId);
            if (admin == null || admin.AdminRole != AdminType.SuperAdmin)
            {
                throw new Exception("User need to a super admin in order to change the request status");
            }
            if (approval == Approval.Pending)
            {
                throw new Exception("Cannot change to Pending state!!");
            }
            var req = await _dbContext.NewAdminRequests.FindAsync(reqId);
            req.ApprovalStatus = approval;
            req.Approver = admin;
            req.Reason = Reason;
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateNewRequest(NewAdminRequest newRequest)
        {
            await _dbContext.NewAdminRequests.AddAsync(newRequest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<NewAdminRequest>> ViewPendingStatus(string userId, int limit)
        {
            var admin = await _userManager.FindByIdAsync(userId);
            if (admin == null || admin.AdminRole != AdminType.SuperAdmin)
            {
                throw new Exception("User need to a super admin in order to change the request status");
            }
            return await Task.Run(() =>
              {
                  return _dbContext.NewAdminRequests.Where(x => x.ApprovalStatus == Approval.Pending).Take(limit).ToList();
              });
        }
    }
}
