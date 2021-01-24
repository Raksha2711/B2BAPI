using System;
using System.Collections.Generic;
using System.Text;
using Data.Db;
using Data.Entity;

namespace B2b.BusinessService
{
    public class SupplierTypeService : Repository<SupplierMaster>, ISupplierService
    {
        public SupplierTypeService(B2bDbContext dbContext) : base(dbContext) { }
    }
}
