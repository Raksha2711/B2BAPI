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
        //[HttpPost]
        //[Route("authorize")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Authorize([FromBody] Command.Entity.Customer model)
        //{
        //    //var result = new HomeModel();
        //    var response = new ServiceResult<string>(string.Empty);
        //    if (model != null && !string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
        //    {
        //        var hasUser = Service.UserExist(model.Email);
        //        if (hasUser)
        //        {
        //            var result = Service.Login(model).Result;
        //            if (!result.Error)
        //            {
        //                return this.BuidResponse(result);
        //            }
        //            else
        //            {
        //                response.AddError("Invalid Credentials");
        //                return this.BuidResponse(response);
        //            }
        //        }
        //        else
        //        {
        //            return this.BuidErrorResponse("User doesn't exist!");
        //        }
        //    }
        //    return this.BuidErrorResponse(ModelState);
        //}
        public IActionResult Index()
        
        {
            return View();
        }
        //[HttpGet]
        //[Route("userprofile")]
        //public IActionResult UserProfile()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var customerId = Convert.ToInt16(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);

        //        var result = new HomeModel();
        //        result.Profile.Customer = CustomerService.Get(customerId);
        //        result.Profile.Travellers = CustomerService.GetTravellers(customerId);
        //        return View(result);
        //    }
        //    else
        //    {
        //        ViewBag.Msg = "Please login to access this page!";
        //        return View();
        //    }

        //}

        //[HttpGet]
        //[Route("generateotp")]
        //[ValidateAntiForgeryToken]
        //public IActionResult GenerateOTP([FromQuery] string email)
        //{

        //    var success = Service.GenerateOTP(email).Result;
        //    if (success)
        //    {
        //        return this.BuidResponse(success);
        //    }
        //    else
        //    {
        //        return this.BuidErrorResponse("Failed");
        //    }

        //}

        //[HttpPost]
        //[Route("validateotp")]
        //[ValidateAntiForgeryToken]
        //public IActionResult ValidateOTP([FromBody] Command.Entity.Customer model)
        //{
        //    var response = new ServiceResult<string>(string.Empty);
        //    var hasUser = Service.UserExist(model.Email);
        //    if (hasUser)
        //    {
        //        var result = Service.Login(model.Email, model.Otp).Result;
        //        if (result != null)
        //        {
        //            return this.BuidResponse(result);
        //        }
        //        else
        //        {
        //            response.AddError("OTP not validated");
        //            return this.BuidResponse(response);
        //        }
        //    }
        //    return this.BuidErrorResponse(ModelState);
        //}

        //[HttpPost]
        //[Route("createaccount")]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateAccount([FromBody] Command.Entity.Customer model)
        //{
        //    ModelState.Remove("FirstName");
        //    ModelState.Remove("LastName");
        //    var response = new ServiceResult<string>(string.Empty);
        //    if (ModelState.IsValid)
        //    {
        //        if (Service.UserExist(model.Email))
        //        {
        //            response.AddError("User already exist!");
        //            return this.BuidResponse(response);
        //        }
        //        var result = Service.SignUp(model);
        //        return this.BuidResponse(result);
        //    }
        //    return this.BuidErrorResponse(ModelState);
        //}

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
