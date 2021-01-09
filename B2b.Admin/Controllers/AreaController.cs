using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.BusinessService;

namespace B2b.Admin.Controllers
{
    public partial class AreaController : BaseController
    {
        IAreaService _service;
        public AreaController(IAreaService service)
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
