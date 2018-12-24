using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Models.IdentityModels;

namespace WebUI.Helpers
{
    public static class UserExtensions
    {
        public static ApplicationUser ToApplicationUser(this User user)
        {
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