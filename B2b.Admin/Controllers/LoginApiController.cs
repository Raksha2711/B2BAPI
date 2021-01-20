using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2b.Admin.Controllers
{
    public partial class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
