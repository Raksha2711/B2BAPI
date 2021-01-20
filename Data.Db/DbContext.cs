using System;
using Microsoft.EntityFrameworkCore;
using Data.Entity;

namespace Data.Db
{
    public class B2bDbContext : DbContext
    {
        public B2bDbContext(DbContextOptions<B2bDbContext> options) : base(options)
        {
        }
        public B2bDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=SilverlineSupplier;Integrated Security=SSPI;");
                //optionsBuilder.UseSqlServer("Server=b2bpotential.cnb1fgovpd8k.ap-south-1.rds.amazonaws.com;Initial Catalog=SilverlineSupplier;Persist Security Info=True;User ID=admin;Password=STELLANS$sd*1;");
            }
        }
        public DbSet<CategoryMaster> CategoryMaster { get; set; }

        public DbSet<BrandMaster> BrandMaster { get; set; }

        public DbSet<SubCategoryMaster> SubCategoryMaster { get; set; }
        public DbSet<SupplierMaster> SupplierMaster { get; set; }
        public DbSet<ServiceMaster> ServiceMaster { get; set; }
    }
}
