using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B2b.BusinessService;
using Core.ApiResponse;

namespace B2b.Admin.Controllers
{

    [Route("api/suppliers/[action]")]
    public class SupplierController : BaseController
    {
        ISupplierService _service;
        public SupplierController(ISupplierService service)
        {
            _service = service;
        }
        public IActionResult List([FromQuery] int offset, [FromQuery] int take = 10)
        {
            var result = new ExecutionResult<dynamic>();
            result.Value = _service.Get().Select(s => new { id = s.Id, title = s.Name }).Take(take).Skip(offset).ToList();
            //,address = s.Address,pincode = s.Pincode , name  = s.ContactPerson1,number =s.Mobile1,email = s.EmailId}).Take(take).Skip(offset).ToList();
            return FromExecutionResult(result);
            //_service

        }

    }
}
