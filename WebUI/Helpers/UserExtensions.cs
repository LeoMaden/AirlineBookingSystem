using AirlineBookingLibrary.Models;
using WebUI.Models.IdentityModels;

namespace WebUI.Helpers
{
    /// <summary>
    /// Provides extension methods for manipulating User objects.
    /// </summary>
    public static class UserExtensions
    {
        /// <summary>
        /// Convert a User to ApplicationUser.
        /// </summary>
        /// <param name="user">The user to convert.</param>
        /// <returns>An ApplicationUser with the same data as User.</returns>
        public static ApplicationUser ToApplicationUser(this User user)
        {
            // Map User to ApplicationUser.
            var output = new ApplicationUser
            {
                Id = user.Id,
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DateCreated = user.DateCreated,
                PasswordHash = user.PasswordHash
            };

            return output;
        }
    }
}