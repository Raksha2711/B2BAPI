using System;
using System.Collections.Generic;
using System.Text;
using Data.Db;
using Data.Entity;

namespace B2b.BusinessService
{
    public class SupplierService : Repository<SupplierMaster>, ISupplierService
    {
        public SupplierService(B2bDbContext dbContext) : base(dbContext) { }
    }
}
