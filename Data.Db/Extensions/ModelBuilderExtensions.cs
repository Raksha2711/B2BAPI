using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Db.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddIdentityRules(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>(i => { i.ToTable("Users", "Auth"); });
            modelBuilder.Entity<IdentityRole>(i => { i.ToTable("Roles", "Auth"); });
            modelBuilder.Entity<IdentityUserRole<string>>(i => { i.ToTable("UserRoles", "Auth"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(i => { i.ToTable("UserLogins", "Auth"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(i => { i.ToTable("RoleClaims", "Auth"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(i => { i.ToTable("UserClaims", "Auth"); });
            modelBuilder.Entity<IdentityUserToken<string>>(i => { i.ToTable("UserTokens", "Auth"); });
        }
    }
}
