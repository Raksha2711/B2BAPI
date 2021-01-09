using Admin.BusinessService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2b.Admin.Controllers
{

    [Route("api/brands/[action]")]
    public partial class BrandController : BaseController
    {
        IBrandService _service;
        public BrandController(IBrandService service)
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
