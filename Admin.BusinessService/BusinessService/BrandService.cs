using System;
using System.Collections.Generic;
using System.Text;
using Data.Entity;
using Data.Db;

namespace Admin.BusinessService
{
    public class BrandService : Repository<BrandMaster>, IBrandService
    {
        //public B2bDbContext _dbContext { get; }
        //BrandService(B2bDbContext dbContext) : base(dbContext)
        //{
        //    //_dbContext = dbContext;
        //}
    }
}
