using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Helpers;

namespace WebUI.Models.IdentityModels
{
    /// <summary>
    /// The IUserStore for this application.
    /// Implements the IUser____Store interfaces required for the 
    /// UserManager and SignInManager to work.
    /// </summary>
    public class ApplicationUserStore : IUserStore<ApplicationUser, int>,
        IUserClaimStore<ApplicationUser, int>, 
        IUserEmailStore<ApplicationUser, int>, 
        IUserPasswordStore<ApplicationUser, int>, 
        IUserPhoneNumberStore<ApplicationUser, int>,
        IUserLockoutStore<ApplicationUser, int>,
        IUserTwoFactorStore<ApplicationUser, int>
    {
        /// <summary>
        /// Private variable for the IDataAccess dependancy.
        /// </summary>
        private IDataAccess _dataAccess;


        /// <summary>
        /// Create a new instance of ApplicationUserStore that accesses
        /// a store using the provided IDataAccess.
        /// </summary>
        /// <param name="dataAccess">The IDataAccess used to access the store.</param>
        public ApplicationUserStore(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }


        async Task IUserClaimStore<ApplicationUser, int>.AddClaimAsync(ApplicationUser user, Claim claim)
        {
            // Do nothing as claims are not currently being stored.
            return;
        }

        async Task IUserStore<ApplicationUser, int>.CreateAsync(ApplicationUser user)
        {
            await _dataAccess.CreateAsync(user);
        }

        async Task IUserStore<ApplicationUser, int>.DeleteAsync(ApplicationUser user)
        {
            await _dataAccess.DeleteAsync(user);
        }

        void IDisposable.Dispose()
        {
            return;
        }

        async Task<ApplicationUser> IUserEmailStore<ApplicationUser, int>.FindByEmailAsync(string email)
        {
            User user = await _dataAccess.FindByEmailAsync(email);
            
            if (user == null)
            {
                // Return default ApplicationUser if no user is found.
                return new ApplicationUser();
            }

            return user.ToApplicationUser();
        }

        async Task<ApplicationUser> IUserStore<ApplicationUser, int>.FindByIdAsync(int userId)
        {
            User user = await _dataAccess.FindByIdAsync(userId);

            if (user == null)
            {
                // Return default ApplicationUser if no user is found.
                return new ApplicationUser();
            }

            return user.ToApplicationUser();
        }

        async Task<ApplicationUser> IUserStore<ApplicationUser, int>.FindByNameAsync(string userName)
        {
            User user = await _dataAccess.FindByNameAsync(userName);

            if (user == null)
            {
                // Return default ApplicationUser if no user is found.
                return new ApplicationUser();
            }

            return user.ToApplicationUser();
        }

        async Task<int> IUserLockoutStore<ApplicationUser, int>.GetAccessFailedCountAsync(ApplicationUser user)
        {
            // Return 0 as lockouts are not being implemented currently.
            return 0;
        }

        async Task<IList<Claim>> IUserClaimStore<ApplicationUser, int>.GetClaimsAsync(ApplicationUser user)
        {
            // Return an empty List<Claim> as claims are not being stored currently.
            return new List<Claim>();
        }

        async Task<string> IUserEmailStore<ApplicationUser, int>.GetEmailAsync(ApplicationUser user)
        {
            return await Task.Run(() => user.Email);
        }

        async Task<bool> IUserEmailStore<ApplicationUser, int>.GetEmailConfirmedAsync(ApplicationUser user)
        {
            // Return true as email is not being confirmed currently.
            return true;
        }

        async Task<bool> IUserLockoutStore<ApplicationUser, int>.GetLockoutEnabledAsync(ApplicationUser user)
        {
            // Return false as lockouts are not being implemented currently.
            return false;
        }

        async Task<DateTimeOffset> IUserLockoutStore<ApplicationUser, int>.GetLockoutEndDateAsync(ApplicationUser user)
        {
            // Return lockout end date as now as lockouts are not being implemented currently.
            return new DateTimeOffset(DateTime.Now, TimeSpan.FromTicks(0));
        }

        async Task<string> IUserPasswordStore<ApplicationUser, int>.GetPasswordHashAsync(ApplicationUser user)
        {
            return await Task.Run(() => user.PasswordHash);
        }

        async Task<string> IUserPhoneNumberStore<ApplicationUser, int>.GetPhoneNumberAsync(ApplicationUser user)
        {
            return await Task.Run(() => user.PhoneNumber);
        }

        async Task<bool> IUserPhoneNumberStore<ApplicationUser, int>.GetPhoneNumberConfirmedAsync(ApplicationUser user)
        {
            // Return true as user phone numbers are not being confirmed currently.
            return true;
        }

        async Task<bool> IUserTwoFactorStore<ApplicationUser, int>.GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            // Return false as two factor auth is not being used currently.
            return false;
        }

        async Task<bool> IUserPasswordStore<ApplicationUser, int>.HasPasswordAsync(ApplicationUser user)
        {
            bool isPasswordNullOrEmpty = await Task.Run(() => string.IsNullOrEmpty(user.PasswordHash));

            // Will return true if password not empty, false otherwise.
            return isPasswordNullOrEmpty == false;
        }

        async Task<int> IUserLockoutStore<ApplicationUser, int>.IncrementAccessFailedCountAsync(ApplicationUser user)
        {
            // Return 0 as lockouts are not being implemented currently.
            return 0;
        }

        async Task IUserClaimStore<ApplicationUser, int>.RemoveClaimAsync(ApplicationUser user, Claim claim)
        {
            // Do nothing as user claims are not currently being stored.
            return;
        }

        async Task IUserLockoutStore<ApplicationUser, int>.ResetAccessFailedCountAsync(ApplicationUser user)
        {
            // Do nothing as lockouts are not being implemented currently.
            return;
        }

        async Task IUserEmailStore<ApplicationUser, int>.SetEmailAsync(ApplicationUser user, string email)
        {
            await Task.Run(() => user.Email = email);
        }

        async Task IUserEmailStore<ApplicationUser, int>.SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            // Do nothing as this feature is not being implemented currently.
            return;
        }

        async Task IUserLockoutStore<ApplicationUser, int>.SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            // Do nothing as this feature is not being implemented currently.
            return;
        }

        async Task IUserLockoutStore<ApplicationUser, int>.SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset lockoutEnd)
        {
            // Do nothing as this feature is not being implemented currently.
            return;
        }

        async Task IUserPasswordStore<ApplicationUser, int>.SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            await Task.Run(() => user.PasswordHash = passwordHash);
        }

        async Task IUserPhoneNumberStore<ApplicationUser, int>.SetPhoneNumberAsync(ApplicationUser user, string phoneNumber)
        {
            await Task.Run(() => user.PhoneNumber = phoneNumber);
        }

        async Task IUserPhoneNumberStore<ApplicationUser, int>.SetPhoneNumberConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            // Do nothing as this feature is not being implemented currently.
            return;
        }

        async Task IUserTwoFactorStore<ApplicationUser, int>.SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
            // Do nothing as this feature is not being implemented currently.
            return;
        }

        async Task IUserStore<ApplicationUser, int>.UpdateAsync(ApplicationUser user)
        {
            await _dataAccess.UpdateAsync(user);
        }
    }
}
