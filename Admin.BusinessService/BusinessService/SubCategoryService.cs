using System;
using System.Collections.Generic;
using System.Text;
using Data.Db;
using Data.Entity;

namespace B2b.BusinessService
{
    public class SubCategoryService : Repository<SubCategoryMaster>, ISubCategoryService
    {
        public SubCategoryService(B2bDbContext dbContext) : base(dbContext) { }
    }
}
