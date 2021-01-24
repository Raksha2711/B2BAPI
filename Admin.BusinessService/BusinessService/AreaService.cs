using System;
using System.Collections.Generic;
using System.Text;
using Data.Db;
using Data.Entity;

namespace B2b.BusinessService
{
    public class AreaService : Repository<AreaMaster>, IAreaService
    {
        public AreaService(B2bDbContext dbContext) : base(dbContext) { }
    }
}
