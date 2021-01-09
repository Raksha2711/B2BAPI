using Core.ApiResponse;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2b.Admin.Controllers
{
    public partial class ServiceController 
    {
        public IActionResult List([FromQuery] int offset, [FromQuery] int take = 10)
        {
            var result = new ExecutionResult<dynamic>();
            result.Value = _service.Get().Select(s => new { id = s.Id, title = s.Name ,address = s.Address }).Take(take).Skip(offset).ToList();
           // ,contact_number = s.ContactNo,email = s.Email}).Take(take).Skip(offset).ToList();
            return FromExecutionResult(result);
            //_service

        }
    }
}
