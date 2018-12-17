using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using AirlineBookingLibrary.Models;
using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Services;
using WebUI.Models.IdentityModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace WebUI
{
    public partial class Startup
    {
        // Define factory for creating instances of UserManager.
        public static Func<UserManager<ApplicationUser, int>> UserManagerFactory { get; private set; }

        public static Func<IOwinContext, SignInManager<ApplicationUser, int>> SignInManagerFactory { get; private set; }


        public void ConfigureAuth(IAppBuilder app)
        {
            // Tell ASP.NET identity framework to use cookie authentication.
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                // Identify authentication type.
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                // Set redirect path when there is an unauthorised (401) attempt.
                LoginPath = new PathString("/account/login")
            });


            // Assign a function to user manager factory. 
            UserManagerFactory = () =>
            {
                // Create a user manager that uses the library's store.
                var userManager = new UserManager<ApplicationUser, int>(new UserStore());

                // Add user validator to validate usernames.
                userManager.UserValidator = new UserValidator<ApplicationUser, int>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                // Add a password validator to verify password complexity.
                userManager.PasswordValidator = new PasswordValidator
                {
                    RequireDigit = false,
                    RequiredLength = 8,
                    RequireLowercase = true,
                    RequireNonLetterOrDigit = false,
                    RequireUppercase = false
                };

                // Add email service for sending email confirmations.
                userManager.EmailService = new EmailService();

                return userManager;
            };

            SignInManagerFactory = (IOwinContext context) =>
            {
                var signInManager = new SignInManager<ApplicationUser, int>(UserManagerFactory.Invoke(), context.Authentication);

                return signInManager;
            };
        }
    }
}