using System;
using Microsoft.EntityFrameworkCore;
using Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Data.Db.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Data.Db
{
    public partial class B2bDbContext : IdentityDbContext<IdentityUser>
    {
        #region constrecture
        public string connection { get; set; }
        public B2bDbContext(DbContextOptions<B2bDbContext> options) : base(options)
        {
        }
        public B2bDbContext(string cn) : base()
        {
            connection = cn;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connection);
                //optionsBuilder.Options
            }
        }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Identity
            modelBuilder.AddIdentityRules();
        }
        //public DbSet<AreaMaster> Area { get; set; }
        //public DbSet<CategoryMaster> CategoryMaster { get; set; }
        //public DbSet<BrandMaster> BrandMaster { get; set; }
        //public DbSet<SubCategoryMaster> SubCategoryMaster { get; set; }
        //public DbSet<SupplierMaster> SupplierMaster { get; set; }
        //public DbSet<ServiceMaster> ServiceMaster { get; set; }
    }
}
