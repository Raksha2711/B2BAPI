using System;
using System.Collections.Generic;
using System.Text;
using Data.Entity;
using Data.Db;
using System.Linq;


namespace B2b.BusinessService
{
    public class BrandService : Repository<BrandMaster>, IBrandService
    {
        public BrandService(B2bDbContext dbContext) : base(dbContext)
        {
        }
        public List<BrandMaster> GetList()
        {
            //return _dbContext.BrandMaster.ToList();
            var result = new List<BrandMaster>();
            var query = (from c in _dbContext.BrandMaster
                         select new { Entity = c });
            var entries = query.ToList();

            foreach (var e in entries)
            {
                var item = e.Entity;
                result.Add(item);
            }
            return result;
        } 
               
                //var result = new List<BrandMaster>();
                ////var isSuperAdmin = User.IsSuperAdmin();
                //var query = (from c in _dbContext.BrandMaster
                //             select new { Entity = c });

            //result.Data = new DataList<CfgCountry>();
            //result.Data.TotalCount = query.Count();
            //if (param.Search != null && !string.IsNullOrEmpty(param.Search.Value))
            //{
            //    var keyword = param.Search.Value.ToLower();
            //    query = query.Where(w => w.Entity.Name.ToLower().Contains(keyword) || w.Entity.Code.ToLower().Contains(keyword));
            //}

            //if (param.Order != null && param.Order.Length > 0)
            //{
            //    foreach (var item in param.Order)
            //    {
            //        if (param.Columns[item.Column].Data.ToLower().Equals(nameof(CfgCountry.Name).ToLower()))
            //            query = item.Dir == DTOrderDir.DESC ? query.OrderByDescending(o => o.Entity.Name) : query.OrderBy(o => o.Entity.Name);
            //        if (param.Columns[item.Column].Data.ToLower().Equals(nameof(CfgCountry.Code).ToLower()))
            //            query = item.Dir == DTOrderDir.DESC ? query.OrderByDescending(o => o.Entity.Code) : query.OrderBy(o => o.Entity.Code);
            //    }
            //}

            //result.Data.FilteredCount = query.Count();
            //if (param.Length > 0)
            //{
            //    query = query.Skip(param.Start).Take(param.Length);
            //}


            //result.Data.Items = new List<CfgCountry>();
            //var entries = query.ToList();

            //foreach (var e in entries)
            //{
            //    var item = e.Entity;
            //   // result..Items.Add(item);
            //}
            //return result;
        //}
        
    }
}
