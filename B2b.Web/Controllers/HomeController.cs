using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using B2b.Web.Models;
using Data.Db;
using B2b.BusinessService;
using Common.Model;
namespace B2b.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        public B2bDbContext _dbContext;
        private IBrandService _brandservice;
        private ISubCategoryService _productservice;
        public HomeController(
            IBrandService brandservice,
            ISubCategoryService productservice,
            B2bDbContext dbContext)
        {
            _brandservice = brandservice;
            _productservice = productservice;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            var Categorylist = _dbContext.CategoryMaster.Where(w => w.Status.Equals(1)).ToList();

            var model = new HomeViewModel
            {
                Brands = _brandservice.List(new Paging { Start = 0, Length = 8 }),
                Products = _productservice.PageList(new Paging { Start = 0, Length = 4 }),
                _category = Categorylist
            };
            return View(model);
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
