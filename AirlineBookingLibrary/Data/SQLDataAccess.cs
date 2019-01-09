using System;
using System.Collections.Generic;
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

        public async Task CreateAddressAsync(User user)
        {
            using (IDbConnection connection = Connection)
            {
                // Add parameters to query.
                var p = new DynamicParameters();
                p.Add("@Id", user.Id);
                p.Add("@StreetAddress", user.Address.StreetAddress);
                p.Add("@Locality", user.Address.Locality);
                p.Add("@City", user.Address.City);
                p.Add("@Postcode", user.Address.Postcode);

                await connection.ExecuteAsync("dbo.spInsertUserAddress", p, commandType: CommandType.StoredProcedure);
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
                p.Add("@PasswordHash", user.PasswordHash);
                p.Add("@Id", user.Id, direction: ParameterDirection.Output);

                await connection.ExecuteAsync("dbo.spInsertUser", p, commandType: CommandType.StoredProcedure);

                // Set user Id to value of output parameter.
                user.Id = p.Get<int>("@Id");

                // Store address of user.
                await CreateAddressAsync(user);
            }
        }

        public Task CreateBookingAsync(Booking booking, User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAddressAsync(User user)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", user.Id);

                await connection.ExecuteAsync("dbo.spDeleteUserAddress", p, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task DeleteAsync(User user)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", user.Id);

                await connection.ExecuteAsync("dbo.spDeleteUser", p, commandType: CommandType.StoredProcedure);

                // Delete user address.
                await DeleteAddressAsync(user);
            }
        }

        public async Task<Address> FindAddressByIdAsync(int userId)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", userId);

                return await connection.QueryFirstAsync<Address>("dbo.spGetUserAddress", p, commandType: CommandType.StoredProcedure);
            }
        }

        public Task<ICollection<Booking>> FindBookingsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
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

                    // Add user address to User object.
                    user.Address = await FindAddressByIdAsync(user.Id);
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

                    // Add user address to User object.
                    user.Address = await FindAddressByIdAsync(user.Id);
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

                    // Add user address to User object.
                    user.Address = await FindAddressByIdAsync(user.Id);
                }
                catch (InvalidOperationException)
                {
                    // User not found.
                }

                return user;
            }
        }

        public Task<ICollection<Flight>> FindFlightsAsync(Airport origin, Airport destination, DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAddressAsync(User user)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", user.Id);
                p.Add("@StreetAddress", user.Address.StreetAddress);
                p.Add("@Locality", user.Address.Locality);
                p.Add("@City", user.Address.City);
                p.Add("@Postcode", user.Address.Postcode);

                await connection.ExecuteAsync("dbo.spUpdateUserAddress", p, commandType: CommandType.StoredProcedure);
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
                p.Add("@PasswordHash", user.PasswordHash);

                await connection.ExecuteAsync("dbo.spUpdateUser", p, commandType: CommandType.StoredProcedure);

                // Update user's address.
                await UpdateAddressAsync(user);
            }
        }
    }
}
