using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingLibrary.Models;
using Dapper;

namespace AirlineBookingLibrary.Data
{
    public class SQLDataAccess : IDataAccess
    {
        public async Task CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetEmailAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetPasswordHashAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetPhoneNumberAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task SetEmailAsync(User user, string email)
        {
            throw new NotImplementedException();
        }

        public async Task SetPasswordHashAsync(User user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public async Task SetPhoneNumberAsync(User user, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
