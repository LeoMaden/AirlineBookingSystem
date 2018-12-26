using Owin;
using System;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using AirlineBookingLibrary.Services;
using WebUI.Models.IdentityModels;
using Microsoft.AspNet.Identity.Owin;

namespace WebUI
{
    public partial class Startup
    {
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
        }
    }
}