using AirlineBookingLibrary.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET /Account/LogIn
        [AllowAnonymous]
        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        // POST /Account/Login
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LogInModel model)
        {
            // Validate information entered by user.
            if (ModelState.IsValid == false)
            {
                return View();
            }

            // Sign user in.
            if (model.UserName == "leo" && model.Password == "password")
            {
                // Create a claim for the user.
                var identity = new ClaimsIdentity(
                    new[] {
                        new Claim(ClaimTypes.Name, "Leo"),
                        new Claim(ClaimTypes.Email, "leo@admin.com"),
                        new Claim(ClaimTypes.MobilePhone, "07794294011"),
                    }, 
                    DefaultAuthenticationTypes.ApplicationCookie);

                var context = Request.GetOwinContext();
                IAuthenticationManager accountManager = context.Authentication;

                accountManager.SignIn(identity);

                // Redirect user to return url or index if null.
                return Redirect(model.ReturnUrl.NullIfEmpty() ?? Url.Action("Index", "Home"));
            }
            

            // Invalid credentials.

            ModelState.AddModelError("", "Username or password was incorrect");
            return View();
        }

        public ActionResult LogOff()
        {
            var context = Request.GetOwinContext();
            IAuthenticationManager accountManager = context.Authentication;

            // Sign user out and redirect to homepage.
            accountManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}