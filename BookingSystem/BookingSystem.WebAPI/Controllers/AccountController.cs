using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BookingSystem.DataAccess.UserManager;
using BookingSystem.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace BookingSystem.WebAPI.Controllers
{
     [RoutePrefix("api/Account")]
    public class AccountController : ApiController
     {
         private readonly IUserManager _userManager;
         private IAuthenticationManager Authentication
         {
             get { return Request.GetOwinContext().Authentication; }
         }

         public AccountController(IUserManager userManager)
         {
             _userManager = userManager;
         }

         [AllowAnonymous]
         [Route("Register")]
         [HttpPost]
         public async Task<IHttpActionResult> Register(User userModel)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             IdentityResult result = await _userManager.RegisterUser(userModel);

             IHttpActionResult errorResult = GetErrorResult(result);

             if (errorResult != null)
             {
                 return errorResult;
             }

             return Ok();
         }

         private IHttpActionResult GetErrorResult(IdentityResult result)
         {
             if (result == null)
             {
                 return InternalServerError();
             }

             if (!result.Succeeded)
             {
                 if (result.Errors != null)
                 {
                     foreach (string error in result.Errors)
                     {
                         ModelState.AddModelError("", error);
                     }
                 }

                 if (ModelState.IsValid)
                 {
                     // No ModelState errors are available to send, so just return an empty BadRequest.
                     return BadRequest();
                 }

                 return BadRequest(ModelState);
             }

             return null;
         }
    }
}