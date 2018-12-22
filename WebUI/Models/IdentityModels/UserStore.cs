using AirlineBookingLibrary;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Helpers;

namespace WebUI.Models.IdentityModels
{
    public class UserStore : IUserStore<ApplicationUser, int>, IUserClaimStore<ApplicationUser, int>, IUserEmailStore<ApplicationUser, int>, IUserPasswordStore<ApplicationUser, int>, IUserPhoneNumberStore<ApplicationUser, int>
    {
        async Task IUserClaimStore<ApplicationUser, int>.AddClaimAsync(ApplicationUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        async Task IUserStore<ApplicationUser, int>.CreateAsync(ApplicationUser user)
        {
            await GlobalConfig.DbContext.CreateAsync(user);
        }

        async Task IUserStore<ApplicationUser, int>.DeleteAsync(ApplicationUser user)
        {
            await GlobalConfig.DbContext.DeleteAsync(user);
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        async Task<ApplicationUser> IUserEmailStore<ApplicationUser, int>.FindByEmailAsync(string email)
        {
            return (await GlobalConfig.DbContext.FindByEmailAsync(email)).ToApplicationUser();
        }

        async Task<ApplicationUser> IUserStore<ApplicationUser, int>.FindByIdAsync(int userId)
        {
            return (await GlobalConfig.DbContext.FindByIdAsync(userId)).ToApplicationUser();
        }

        async Task<ApplicationUser> IUserStore<ApplicationUser, int>.FindByNameAsync(string userName)
        {
            return (await GlobalConfig.DbContext.FindByNameAsync(userName)).ToApplicationUser();
        }

        async Task<IList<Claim>> IUserClaimStore<ApplicationUser, int>.GetClaimsAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        async Task<string> IUserEmailStore<ApplicationUser, int>.GetEmailAsync(ApplicationUser user)
        {
            return await Task.Run(() => user.Email);
        }

        async Task<bool> IUserEmailStore<ApplicationUser, int>.GetEmailConfirmedAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        async Task<bool> IUserPasswordStore<ApplicationUser, int>.HasPasswordAsync(ApplicationUser user)
        {
            bool isPasswordNullOrEmpty = await Task.Run(() => string.IsNullOrEmpty(user.PasswordHash));

            // Will return true if password not empty, false otherwise.
            return isPasswordNullOrEmpty == false;
        }

        async Task IUserClaimStore<ApplicationUser, int>.RemoveClaimAsync(ApplicationUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        async Task IUserEmailStore<ApplicationUser, int>.SetEmailAsync(ApplicationUser user, string email)
        {
            await Task.Run(() => user.Email = email);
        }

        async Task IUserEmailStore<ApplicationUser, int>.SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        async Task IUserStore<ApplicationUser, int>.UpdateAsync(ApplicationUser user)
        {
            await GlobalConfig.DbContext.UpdateAsync(user);
        }
    }
}
