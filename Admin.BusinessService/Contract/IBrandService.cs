using System;
using System.Collections.Generic;
using System.Text;
using Data.Entity;
using Common.Model;

namespace B2b.BusinessService
{
    public interface IBrandService : IRepository<BrandMaster>
    {
        List<BrandMaster> GetList();
        List<DropdownViewModel> List(Paging model);
    }
}
