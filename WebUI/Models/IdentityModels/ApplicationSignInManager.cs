using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace WebUI.Models.IdentityModels
{
    /// <summary>
    /// The SignInManager for this application. Allows methods in the 
    /// AspNet.Identity.Owin.SignInManager class to be overridden.
    /// </summary>
    public class ApplicationSignInManager : SignInManager<ApplicationUser, int>
    {
        /// <summary>
        /// Create a new instance of ApplicationSignInManager using
        /// the provided UserManager.
        /// </summary>
        /// <param name="userManager">The UserManager for the SignInManager to use.</param>
        public ApplicationSignInManager(UserManager<ApplicationUser, int> userManager)
            // Call base constructor, passing UserManager and the IAuthentiationManager
            // from the Owin context as a parameter
            :base(userManager, HttpContext.Current.GetOwinContext().Authentication)
        {
            
        }
    }
}