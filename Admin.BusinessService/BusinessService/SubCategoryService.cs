using System;
using System.Collections.Generic;
using System.Text;
using Data.Db;
using Data.Entity;
using Common.Model;
using System.Linq;

namespace B2b.BusinessService
{
    public class SubCategoryService : Repository<SubCategoryMaster>, ISubCategoryService
    {
        public SubCategoryService(B2bDbContext dbContext) : base(dbContext) { }
        public List<DropdownViewModel> PageList(Paging model)
        {
            return _dbContext.SubCategoryMaster.Where(w => w.Status == 1)
                 .Select(s => new DropdownViewModel { key = s.Name, value = s.Image })
                 .Take(model.Length).Skip(model.Start).ToList();
        }
    }
}
