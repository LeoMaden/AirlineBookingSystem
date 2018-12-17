using AirlineBookingLibrary.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Data
{
    public class UserStore : IUserStore<User, int>, IUserClaimStore<User, int>, IUserEmailStore<User, int>, IUserPasswordStore<User, int>, IUserPhoneNumberStore<User, int>
    {
        Task IUserClaimStore<User, int>.AddClaimAsync(User user, Claim claim)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<User, int>.CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<User, int>.DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        Task<User> IUserEmailStore<User, int>.FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserStore<User, int>.FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserStore<User, int>.FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        Task<IList<Claim>> IUserClaimStore<User, int>.GetClaimsAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserEmailStore<User, int>.GetEmailAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserEmailStore<User, int>.GetEmailConfirmedAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserPasswordStore<User, int>.GetPasswordHashAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<string> IUserPhoneNumberStore<User, int>.GetPhoneNumberAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserPhoneNumberStore<User, int>.GetPhoneNumberConfirmedAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserPasswordStore<User, int>.HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task IUserClaimStore<User, int>.RemoveClaimAsync(User user, Claim claim)
        {
            throw new NotImplementedException();
        }

        Task IUserEmailStore<User, int>.SetEmailAsync(User user, string email)
        {
            throw new NotImplementedException();
        }

        Task IUserEmailStore<User, int>.SetEmailConfirmedAsync(User user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        Task IUserPasswordStore<User, int>.SetPasswordHashAsync(User user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        Task IUserPhoneNumberStore<User, int>.SetPhoneNumberAsync(User user, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        Task IUserPhoneNumberStore<User, int>.SetPhoneNumberConfirmedAsync(User user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        Task IUserStore<User, int>.UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }


    }
}
