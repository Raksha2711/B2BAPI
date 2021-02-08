using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entity;
using Common.Model;

namespace B2b.Web.Models
{
    public class HomeViewModel 
    {
        public List<BrandMaster> _brand { get; set; }
        public List<DropdownViewModel> Brands { get; set; }
        public List<DropdownViewModel> Products { get; set; }
        public List<CategoryMaster> _category { get; set; }
        public List<SubCategoryMaster> _product { get; set; }
    }
}
