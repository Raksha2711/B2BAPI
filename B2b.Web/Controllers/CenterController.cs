using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace B2b.Web.Controllers
{
    public class CenterController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
