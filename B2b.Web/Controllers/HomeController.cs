using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using B2b.Web.Models;
using Data.Db;

namespace B2b.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        public B2bDbContext _dbContext;
        public HomeController(B2bDbContext dbContext)
        {
            _dbContext = dbContext;
            //  _configuration = configuration;
        }
        public IActionResult Index()
        {
            var list = _dbContext.BrandMaster.Where(w => w.Status.Equals("1")).ToList();
            return View(list);
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{

        //    return View();
        //}
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
