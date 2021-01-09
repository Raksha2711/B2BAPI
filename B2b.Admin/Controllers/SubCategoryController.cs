using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.BusinessService;

namespace B2b.Admin.Controllers
{
    
        [Route("api/products/[action]")]
        public partial class SubCategoryController : BaseController
        {
            ISubCategoryService _service;
            public SubCategoryController(ISubCategoryService service)
            {
                _service = service;
            }
            public IActionResult Index()
            {
                return View();
            }
            public IActionResult Update(int id)
            {
                return View();
            }
        }
    
}
