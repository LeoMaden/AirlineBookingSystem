using AirlineBookingLibrary.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Models.IdentityModels;

namespace WebUI.Controllers
{
    /// <summary>
    /// The controller responsible for handling account requests and
    /// user authentication.
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        // Create private fields for UserManager and SignInManager.
        private UserManager<ApplicationUser, int> _userManager;
        private SignInManager<ApplicationUser, int> _signInManager;

        
        /// <summary>
        /// Create a new AccountController instance using supplied
        /// UserManager and SignInManager.
        /// </summary>
        /// <param name="userManager">The UserManager object that will manage users</param>
        /// <param name="signInManager">The SignInManager object that will manage user sign ins</param>
        public AccountController(UserManager<ApplicationUser, int> userManager, SignInManager<ApplicationUser, int> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        //
        // GET /Account/LogIn
        [AllowAnonymous]
        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            // Add return url to model.
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

            // Sign in user asynchronously.
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            switch (result)
            {
                case SignInStatus.Success:
                    // Redirect user to return url or index page if there is no return url.
                    return Redirect(model.ReturnUrl.NullIfEmpty() ?? Url.Action("Index", "Home"));

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
            _signInManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

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
            // Check model is valid.
            if (ModelState.IsValid == false)
            {
                return View();
            }
            
            // Map RegisterModel to ApplicationUser.
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

            // Create the user.
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Sign user in and redirect to home.
                await _signInManager.SignInAsync(user, false, true);
                return RedirectToAction("Index", "Home");
            }

            // Log in did not succeed.
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
            
        }
    }
}