using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B2b.BusinessService;
using Core.ApiResponse;

namespace B2b.Admin.Controllers
{

    [Route("api/products/[action]")]
    public class SubCategoryController : BaseController
    {
        ISubCategoryService _service;
        public SubCategoryController(ISubCategoryService service)
        {
            _service = service;
        }
        public IActionResult List([FromQuery] int offset, [FromQuery] int take = 10)
        {
            var result = new ExecutionResult<dynamic>();
            result.Value = _service.Get().Select(s => new { Id = s.Id, Title = s.Name }).Take(take).Skip(offset).ToList();
            return FromExecutionResult(result);
            //_service
        }
    }

}
