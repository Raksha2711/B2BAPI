using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Claims;
using Core.ApiResponse;
using System.Text;

namespace B2b.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected int? GetCurrentUserId()
        {
            if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
                return userId;
            return null;
        }

        protected IActionResult FromExecutionResult(ExecutionResult result)
        {
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Errors);
        }

        protected IActionResult FromExecutionResult<T>(ExecutionResult<T> result, object value = null)
        {
            if (result.Success)
                return Ok(value ?? result);
            return BadRequest(result.Errors);
        }

        protected async Task FromFileErrorResult<T>(ExecutionResult<T> result)
        {
            var errorString = JsonConvert.SerializeObject(result.Errors.ToList());
            Response.ContentLength = errorString.Length;
            Response.ContentType = "application/json";
            Response.StatusCode = 400;
            var bytes = Encoding.UTF8.GetBytes(errorString);
            await Response.Body.WriteAsync(bytes, 0, errorString.Length);
            await Response.Body.FlushAsync();
        }
    }
}
