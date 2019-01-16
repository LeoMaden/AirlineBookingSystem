using Microsoft.AspNet.Identity;

namespace WebUI.Models.IdentityModels
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        /// <summary>
        /// Create a new instance of ApplicationUserManager using the
        /// provided store.
        /// </summary>
        /// <param name="store">The IUserStore used to persist user information.</param>
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store) 
            // Call base constructor, passing store as a parameter.
            : base(store)
        {
            // Add user validator to validate usernames.
            UserValidator = new UserValidator<ApplicationUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Add a password validator to verify password complexity.
            PasswordValidator = new PasswordValidator
            {
                RequireDigit = false,
                RequiredLength = 8,
                RequireLowercase = true,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false
            };
        }
    }
}