using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.Model;
using B2b.BusinessService;

namespace B2b.Web.Controllers
{
    public class BrandController : Controller
    {
        private IBrandService _brandservice;
        public BrandController(IBrandService brandservice)
        {
            _brandservice = brandservice;
        }
        public IActionResult Index()
        {
            return View(_brandservice.Find(f => f.Status.Equals("1")).ToList());
        }
    }
}
