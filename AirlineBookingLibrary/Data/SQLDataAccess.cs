using System;
using System.Data;
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

                await connection.ExecuteAsync("dbo.spInsertUser", p, commandType: CommandType.StoredProcedure);

                // Set user Id to value of output parameter.
                user.Id = p.Get<int>("@Id");
            }
        }

        public async Task DeleteAsync(User user)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", user.Id);

                await connection.ExecuteAsync("dbo.spDeleteUser", p, commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Email", email);

                User user = null;

                try
                {
                    user = await connection.QueryFirstAsync<User>("dbo.spGetUsersByEmail", p, commandType: CommandType.StoredProcedure);
                }
                catch (InvalidOperationException)
                {
                    // User not found.
                }

                return user;
            }
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", userId);

                User user = null;

                try
                {
                    user = await connection.QueryFirstAsync<User>("dbo.spGetUserById", p, commandType: CommandType.StoredProcedure);
                }
                catch (InvalidOperationException)
                {
                    // User not found.
                }

                return user;
            }
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Username", userName);

                User user = null;

                try
                {
                    user = await connection.QueryFirstAsync<User>("dbo.spGetUsersByName", p, commandType: CommandType.StoredProcedure);
                }
                catch (InvalidOperationException)
                {
                    // User not found.
                }

                return user;
            }
        }

        public async Task UpdateAsync(User user)
        {
            using (IDbConnection connection = Connection)
            {
                // Add parameters to query.
                var p = new DynamicParameters();
                p.Add("@Id", user.Id);
                p.Add("@Title", user.Title);
                p.Add("@FirstName", user.FirstName);
                p.Add("@LastName", user.LastName);
                p.Add("@UserName", user.UserName);
                p.Add("@DateOfBirth", user.DateOfBirth);
                p.Add("@Email", user.Email);
                p.Add("@PhoneNumber", user.PhoneNumber);

                await connection.ExecuteAsync("dbo.spUpdateUser", p, commandType: CommandType.StoredProcedure);
                
            }
        }
    }
}
