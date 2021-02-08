using System;
using System.Collections.Generic;
using System.Text;
using Data.Db;
using Common.Model;
using System.Linq;
namespace B2b.BusinessService
{
    public class DropdownService : IDropdownService
    {
        internal readonly B2bDbContext _dbContext;
        public DropdownService(B2bDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Dictionary<string, string> GetRegionddl()
        {
            return _dbContext.AreaMaster.Where(w => w.Status == 1)
                .Select(s => new { key = s.Id, value = s.Name })
                .ToDictionary(k => k.key.ToString(), v => v.value);
        }
        public Dictionary<string, string> GetCategoryddl()
        {
            return _dbContext.CategoryMaster.Where(w => w.Status == 1)
                .Select(s => new { key = s.Id, value = s.Name })
                .ToDictionary(k => k.key.ToString(), v => v.value);
        }
        public Dictionary<string, string> GetBranddl()
        {
            return _dbContext.BrandMaster.Where(w => w.Status == "1")
                .Select(s => new { key = s.Id, value = s.Name })
                .ToDictionary(k => k.key.ToString(), v => v.value);
        }
        public Dictionary<string, string> GetProductddl(int categoryid)
        {
            if (categoryid == 0)
                return _dbContext.SubCategoryMaster.Where(w => w.Status == 1)
                    .Select(s => new { key = s.Id, value = s.Name })
                    .ToDictionary(k => k.key.ToString(), v => v.value);
            else
            {
                return (from b in _dbContext.BrandMapping
                        join sc in _dbContext.SubCategoryMaster on b.Name equals sc.Id.ToString()
                        where sc.Status == 1 && b.Status == 1
                        select new
                        {
                            key = sc.Id,
                            value = sc.Name
                        })
                        .ToDictionary(k => k.key.ToString(), v => v.value);

            }
        }
        public List<DropdownViewModel> GetProductddlByBrandId(int brandid)
        {

            return (from b in _dbContext.BrandMapping
                    join sc in _dbContext.SubCategoryMaster on b.Name equals sc.Id.ToString()
                    where sc.Status == 1 && b.Status == 1 && b.Brand==brandid
                    select new DropdownViewModel
                    {
                        key = sc.Id.ToString(),
                        value = sc.Name
                    })
                    .ToList();


        }
    }

}
