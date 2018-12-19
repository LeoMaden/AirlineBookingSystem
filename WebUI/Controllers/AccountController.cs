using AirlineBookingLibrary.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Models.IdentityModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser, int> UserManager;

        public SignInManager<ApplicationUser, int> SignInManager
        {
            get => Startup.SignInManagerFactory(HttpContext.GetOwinContext());
        }


        public AccountController() : this(Startup.UserManagerFactory.Invoke())
        {

        }

        public AccountController(UserManager<ApplicationUser, int> userManager)
        {
            this.UserManager = userManager;
        }


        //
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

        //
        // POST /Account/LogIn
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(LogInModel model)
        {
            // Validate information entered by user.
            if (ModelState.IsValid == false)
            {
                return View();
            }

            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction(model.ReturnUrl.NullIfEmpty() ?? Url.Action("Index", "Home"));

                case SignInStatus.Failure:
                    ModelState.AddModelError("", "Username or password was incorrect");
                    return View();

                default:
                    return View();
            }

        }

        //
        // POST /Account/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {
            // Sign user out and redirect to homepage.
            SignInManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Home");
        }

        //
        // GET /Account/Register
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST /Account/Register
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            // Model is valid.
            // Map RegisterModel to ApplicationUser
            var user = new ApplicationUser
            {
                Title = model.Title,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                DateOfBirth = model.DateOfBirth,
                Address = model.SelectedAddress,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                DateCreated = DateTime.Now
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, false, true);
                return RedirectToAction("Index", "Home");
            }

            // Log in did not succeed.
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
            
        }


        private async Task SignIn(ApplicationUser user)
        {
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            SignInManager.AuthenticationManager.SignIn(identity);
        }
    }
}