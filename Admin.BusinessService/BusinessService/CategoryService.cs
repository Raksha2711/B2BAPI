using System;
using System.Collections.Generic;
using System.Text;
using Data.Db;
using Data.Entity;
namespace B2b.BusinessService
{
    public class CategoryService : Repository<CategoryMaster>, ICategoryService
    {
        public CategoryService(B2bDbContext dbContext) : base(dbContext) { }
    }
}
