using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingLibrary.Models;
using Dapper;

namespace AirlineBookingLibrary.Data
{
    public class SQLDataAccess : IDataAccess
    {
        private IDbConnection Connection
        {
            get
            {
                return new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString);
            }
        }

        public async Task CreateAsync(User user)
        {
            using (IDbConnection connection = Connection)
            {
                // Add parameters to query.
                var p = new DynamicParameters();
                p.Add("@Title", user.Title);
                p.Add("@FirstName", user.FirstName);
                p.Add("@LastName", user.LastName);
                p.Add("@UserName", user.UserName);
                p.Add("@DateOfBirth", user.DateOfBirth);
                p.Add("@Email", user.Email);
                p.Add("@PhoneNumber", user.PhoneNumber);
                p.Add("@DateCreated", user.DateCreated);
                p.Add("@Id", user.Id, direction: ParameterDirection.Output);

                await connection.ExecuteAsync("spInsertUser", p, commandType: CommandType.StoredProcedure);

                // Set user Id to value of output parameter.
                user.Id = p.Get<int>("@Id");
            }
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
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", user.Id);
                p.Add("@PasswordHash", passwordHash);

                await connection.ExecuteAsync("spSetUserPasswordHash", p, commandType: CommandType.StoredProcedure);
            }
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
