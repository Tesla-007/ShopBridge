using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopAuth.Domain.Entities;
using ShopAuth.Domain.SeedData;

namespace ShopAuth.Domain.ShopBridgeDb
{
    public class ShopBridgeDbContext : IdentityDbContext
    {
        public DbSet<NewAdminRequest> NewAdminRequests { get; set; }
        public ShopBridgeDbContext(DbContextOptions<ShopBridgeDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(SeedSuperAdmin.AddRole());
            modelBuilder.Entity<IdentityAdmin>().HasData(SeedSuperAdmin.AddData());
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(SeedSuperAdmin.LinkSuperAdminAndRole());

        }
    }
}
