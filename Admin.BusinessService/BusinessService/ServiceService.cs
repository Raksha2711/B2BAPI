using System;
using System.Collections.Generic;
using System.Text;
using Data.Db;
using Data.Entity;

namespace B2b.BusinessService
{
   public class ServiceService : Repository<ServiceMaster>, IServiceService
    {
        public ServiceService(B2bDbContext dbContext) : base(dbContext) { }
    }
}
