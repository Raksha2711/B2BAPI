using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using B2b.BusinessService;

namespace B2b.Web.Controllers
{
    public class ProductController : BaseController
    {
        ISubCategoryService _productservice;
        public ProductController(ISubCategoryService productservice)
        {
            _productservice = productservice;
        }
        public IActionResult Index()
        {
            return View(_productservice.Find(f => f.Status == 1).ToList());
        }
    }
}
