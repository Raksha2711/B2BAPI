using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.BusinessService;
using Microsoft.AspNetCore.Mvc;

namespace B2b.Admin.Controllers
{
    [Route("api/service_centres/[action]")]
    public partial class ServiceController : BaseController
    {
        IServiceService _service;
        public ServiceController(IServiceService service)
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
