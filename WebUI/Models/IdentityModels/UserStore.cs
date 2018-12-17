using AirlineBookingLibrary.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Models.IdentityModels
{
    public class UserStore : IUserStore<ApplicationUser, int>, IUserClaimStore<ApplicationUser, int>, IUserEmailStore<ApplicationUser, int>, IUserPasswordStore<ApplicationUser, int>, IUserPhoneNumberStore<ApplicationUser, int>
    {
        Task IUserClaimStore<ApplicationUser, int>.AddClaimAsync(ApplicationUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<ApplicationUser, int>.CreateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<ApplicationUser, int>.DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        Task<ApplicationUser> IUserEmailStore<ApplicationUser, int>.FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        Task<ApplicationUser> IUserStore<ApplicationUser, int>.FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        Task<ApplicationUser> IUserStore<ApplicationUser, int>.FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        Task<IList<Claim>> IUserClaimStore<ApplicationUser, int>.GetClaimsAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserEmailStore<ApplicationUser, int>.GetEmailAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserEmailStore<ApplicationUser, int>.GetEmailConfirmedAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserPasswordStore<ApplicationUser, int>.GetPasswordHashAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserPhoneNumberStore<ApplicationUser, int>.GetPhoneNumberAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserPhoneNumberStore<ApplicationUser, int>.GetPhoneNumberConfirmedAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserPasswordStore<ApplicationUser, int>.HasPasswordAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        Task IUserClaimStore<ApplicationUser, int>.RemoveClaimAsync(ApplicationUser user, Claim claim)
        {
            throw new NotImplementedException();
        }

        Task IUserEmailStore<ApplicationUser, int>.SetEmailAsync(ApplicationUser user, string email)
        {
            throw new NotImplementedException();
        }

        Task IUserEmailStore<ApplicationUser, int>.SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        Task IUserPasswordStore<ApplicationUser, int>.SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        Task IUserPhoneNumberStore<ApplicationUser, int>.SetPhoneNumberAsync(ApplicationUser user, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        Task IUserPhoneNumberStore<ApplicationUser, int>.SetPhoneNumberConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<ApplicationUser, int>.UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
