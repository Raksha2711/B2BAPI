using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.BusinessService;

namespace B2b.Admin.Controllers
{
    
        [Route("api/suppliers/[action]")]
        public partial class SupplierController : BaseController
        {
            ISupplierService _service;
            public SupplierController(ISupplierService service)
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
