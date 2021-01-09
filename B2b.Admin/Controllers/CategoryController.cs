using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.BusinessService;

namespace B2b.Admin.Controllers
{
    [Route("api/verticals/[action]")]
    public partial class CategoryController : BaseController
    {
        ICategoryService _service;
        public CategoryController(ICategoryService service)
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
