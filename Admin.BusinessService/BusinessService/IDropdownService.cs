using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace B2b.BusinessService
{
   public interface IDropdownService
    {
        Dictionary<string, string> GetRegionddl();
        Dictionary<string, string> GetCategoryddl();
        Dictionary<string, string> GetProductddl(int categoryid);
        Dictionary<string, string> GetBranddl();
        List<DropdownViewModel> GetProductddlByBrandId(int brandid);
    }
}
