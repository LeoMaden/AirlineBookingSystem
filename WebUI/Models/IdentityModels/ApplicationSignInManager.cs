using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.IdentityModels
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, int>
    {
        /// <summary>
        /// Create a new instance of ApplicationSignInManager using
        /// the provided UserManager.
        /// </summary>
        /// <param name="userManager"></param>
        public ApplicationSignInManager(UserManager<ApplicationUser, int> userManager)
            // Call base constructor, passing userManager and the IAuthentiationManager
            // from the Owin context as a parameter
            :base(userManager, HttpContext.Current.GetOwinContext().Authentication)
        {
            
        }
    }
}