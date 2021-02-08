using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using B2b.BusinessService;

namespace B2b.Web.Controllers
{
    [Route("api/dropdown/[action]")]
    public class DropdownController : Controller
    {
        internal readonly IDropdownService _service;
        public DropdownController(IDropdownService service)
        {
            _service = service;
        }
        public IActionResult Region()
        {
            return Json(_service.GetRegionddl());
        }
        public IActionResult Brand()
        {
            var result = _service.GetBranddl();
            return Json(result);
        }
        public IActionResult Categoty()
        {
            return Json(_service.GetCategoryddl());
        }
        public IActionResult Product([FromQuery] int cascade)
        {
            if (cascade ==0)
            return Json(_service.GetProductddl(cascade));
            else
                return Json(_service.GetProductddlByBrandId(cascade));
        }
    }
}
