using System;
using System.Collections.Generic;
using System.Text;
using Data.Entity;
using Data.Db;
using System.Linq;
using Common.Model;

namespace B2b.BusinessService
{
    public class BrandService : Repository<BrandMaster>, IBrandService
    {
        public BrandService(B2bDbContext dbContext) : base(dbContext)
        {
        }
        public List<BrandMaster> GetList()
        {
            return _dbContext.BrandMaster.ToList();
        }
        public List<DropdownViewModel> List(Paging model)
        {
            return _dbContext.BrandMaster.Where(w => w.Status == "1")
                 .Select(s => new DropdownViewModel { key = s.Name, value = s.Image })
                 .Take(model.Length).Skip(model.Start).ToList();
        }
    }
}
