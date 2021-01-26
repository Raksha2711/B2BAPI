using Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Db.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddIdentityRules(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>(i => { i.ToTable("Users", "auth"); });
            modelBuilder.Entity<IdentityRole>(i => { i.ToTable("Roles", "auth"); });
            modelBuilder.Entity<IdentityUserRole<string>>(i => { i.ToTable("UserRoles", "auth"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(i => { i.ToTable("UserLogins", "auth"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(i => { i.ToTable("RoleClaims", "auth"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(i => { i.ToTable("UserClaims", "auth"); });
            modelBuilder.Entity<IdentityUserToken<string>>(i => { i.ToTable("UserTokens", "auth"); });
        }
    }
}
