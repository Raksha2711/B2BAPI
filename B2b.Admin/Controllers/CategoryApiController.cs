using Core.ApiResponse;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2b.Admin.Controllers
{
    public partial  class CategoryController 
    {
        public IActionResult List([FromQuery] int offset, [FromQuery] int take = 10)
        {
            var result = new ExecutionResult<dynamic>();
            result.Value = _service.Get().Select(s => new { Id = s.Id, Title = s.Name }).Take(take).Skip(offset).ToList();
            return FromExecutionResult(result);
            //_service
        }
    }
}
