using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2b.Admin.Controllers
{
    public class LoginController : Controller
    {
        
        public IActionResult Index()
        
        {
            return View();
        }
        
        [HttpPost]
        [Route("externallogin")]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string redirect)
        {
            if (!string.IsNullOrEmpty(provider) && !string.IsNullOrEmpty(redirect))
            {
                try
                {
                    return new ChallengeResult(provider, new AuthenticationProperties
                    {
                        RedirectUri = Url.Action("ExternalLoginCallback", "login", new { redirect })
                    });
                }
                catch (Exception ex)
                {

                    return StatusCode(500);
                }
            }
            else
            {
                return StatusCode(500);
            }
        }
        [HttpGet]
        [Route("externallogincallback")]
        public async Task<IActionResult> ExternalLoginCallback(string redirect = null, string remoteError = null)
        {
            redirect = redirect ?? Url.Content("~/");
            if (remoteError != null)
            {
                throw new Exception($"Error from external provider : {remoteError}");
            }
            var contextDetails = await HttpContext.AuthenticateAsync("Cookies");
            if (contextDetails is null || contextDetails.Principal.Claims.Count() == 0)
            {
                throw new Exception($"Problem loading login information");
            }
           // LoginViewModel result = Service.Login(contextDetails);
            //Token = result.Token;
           // TempData["SignIn"] = result.Error;
            return Redirect(redirect);
        }
    }
}
