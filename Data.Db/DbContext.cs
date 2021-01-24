using System;
using Microsoft.EntityFrameworkCore;
using Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Data.Db.Extensions;
using Microsoft.AspNetCore.Identity;
using Data.Entity;

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
            
            modelBuilder.Entity<StaffMaster>(entity =>
            {
                entity.Property(e => e.ContactNo).HasColumnType("numeric(11, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Remark).HasMaxLength(250);
            });

            modelBuilder.Entity<StateMaster>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SubCategoryMapping>(entity =>
            {
                entity.Property(e => e.ContactNo).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ContactPerson).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.VisibleContact)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VisibleDesg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VisibleEmail)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VisiblePerson)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SubCategoryMaster>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Remark).HasMaxLength(250);
            });

            modelBuilder.Entity<SupplierMapping>(entity =>
            {
                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SubCategory).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<SupplierMaster>(entity =>
            {
                entity.Property(e => e.ContactPerson1).HasMaxLength(100);

                entity.Property(e => e.ContactPerson2).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmailId).HasMaxLength(100);

                entity.Property(e => e.Mobile1).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Mobile2).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Pincode).HasMaxLength(6);
            });

            modelBuilder.Entity<SupplierTypeMaster>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TransactionData>(entity =>
            {
                entity.Property(e => e.CategoryId).HasMaxLength(50);

                entity.Property(e => e.ItemId).HasMaxLength(50);

                entity.Property(e => e.SupplierId).HasMaxLength(50);

                entity.Property(e => e.SupplierType).HasMaxLength(50);
            });
            // Identity
            modelBuilder.AddIdentityRules();
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<AreaMaster> AreaMaster { get; set; }
        public virtual DbSet<BrandMapping> BrandMapping { get; set; }
        public virtual DbSet<BrandMaster> BrandMaster { get; set; }
        public virtual DbSet<CategoryMaster> CategoryMaster { get; set; }
        public virtual DbSet<DesignationMaster> DesignationMaster { get; set; }
        
        public virtual DbSet<ServiceMaster> ServiceMaster { get; set; }
        public virtual DbSet<StaffMaster> StaffMaster { get; set; }
        public virtual DbSet<StateMaster> StateMaster { get; set; }
        public virtual DbSet<SubCategoryMapping> SubCategoryMapping { get; set; }
        public virtual DbSet<SubCategoryMaster> SubCategoryMaster { get; set; }
        public virtual DbSet<SupplierMapping> SupplierMapping { get; set; }
        public virtual DbSet<SupplierMaster> SupplierMaster { get; set; }
        public virtual DbSet<SupplierTypeMaster> SupplierTypeMaster { get; set; }
        public virtual DbSet<TransactionData> TransactionData { get; set; }

    }
}
