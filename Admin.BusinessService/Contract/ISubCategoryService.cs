using System;
using System.Collections.Generic;
using System.Text;
using Common.Model;
using Data.Entity;

namespace B2b.BusinessService
{
    public interface ISubCategoryService : IRepository<SubCategoryMaster>
    {
        List<DropdownViewModel> PageList(Paging model);
    }
}
