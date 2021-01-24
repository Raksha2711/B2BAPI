using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B2b.BusinessService;
using Core.ApiResponse;
using Data.Entity;

namespace B2b.Api.Controllers
{
    [Route("api/verticals/[action]")]
    public class CategoryController : BaseController
    {
        ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        public IActionResult List([FromQuery] int offset, [FromQuery] int take = 10)
        {
            var result = new ExecutionResult<BrandMaster>();
            //result.Value = _service.Get().Select(s => new { Id = s.Id, Title = s.Name }).Take(take).Skip(offset).ToList();
            return FromExecutionResult(result);
            //_service
        }
    }
}
