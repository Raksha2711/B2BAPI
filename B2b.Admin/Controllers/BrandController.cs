using B2b.BusinessService;
using Core.ApiResponse;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2b.Api.Controllers
{

    [Route("api/brands/[action]")]
    public class BrandController : BaseController
    {
        IBrandService _service;
        public BrandController(IBrandService service)
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
        public IActionResult List([FromQuery] int offset, [FromQuery] int take = 10)
        {
            var result = new ExecutionResult<dynamic>();
            result.Value = _service.Get().Select(s => new { Id = s.Id, Name = s.Name }).Take(take).Skip(offset).ToList();
            return FromExecutionResult(result);
            //_service
        }
    }
}
