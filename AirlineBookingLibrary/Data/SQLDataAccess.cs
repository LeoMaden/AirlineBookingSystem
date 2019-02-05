using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AirlineBookingLibrary.Models;
using Dapper;

namespace AirlineBookingLibrary.Data
{
    /// <summary>
    /// An implementation of the IDataAccess interface that uses a SQL Server
    /// as the persistant data store.
    /// </summary>
    public class SQLDataAccess : IDataAccess
    {
        /// <summary>
        /// Gets an IDbConnection to the database referenced in GlobalConfig.ConnectionString.
        /// </summary>
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

        public async Task CreateBookingAsync(Booking booking, User user)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@BookingReference", booking.BookingReference);
                p.Add("@UserId", user.Id);
                p.Add("@OutFlight", booking.FlightsDetails.Outbound);
                p.Add("@InFlight", booking.FlightsDetails.Inbound);
                p.Add("@NumberAdults", booking.FlightsDetails.NumberAdults);
                p.Add("@NumberChildren", booking.FlightsDetails.NumberChildren);
                p.Add("@TravelClass", booking.FlightsDetails.TravelClass);
                p.Add("@Last4CardDigits", booking.Last4CardDigits);
                p.Add("@CardType", booking.CardType);
                p.Add("@Price", booking.FlightsDetails.Price);
                p.Add("@DateTimeCreated", booking.DateTimeCreated);

                await connection.ExecuteAsync("dbo.spInsertBooking", p, commandType: CommandType.StoredProcedure);

                // Set booking Id to value of output parameter.
                booking.Id = p.Get<int>("@Id");
            }
        }

        public async Task CreateFlightAsync(Flight flight)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@FlightScheduleId", flight.Schedule.Id);
                p.Add("@OriginAirport", flight.OriginAirport);
                p.Add("@DestinationAirport", flight.DestinationAirport);
                p.Add("@DepartureDateTime", flight.DepartureDateTime);
                p.Add("@ArrivalDateTime", flight.ArrivalDateTime);

                await connection.ExecuteAsync("dbo.spInsertFlight", p, commandType: CommandType.StoredProcedure);

                flight.Id = p.Get<int>("@Id");
            }
        }

        public Task CreateStaffAsync(Staff staff)
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

        public Task DeleteFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStaffAsync(Staff staff)
        {
            throw new NotImplementedException();
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

        public async Task<ICollection<Booking>> FindBookingsByUserIdAsync(int userId)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@UserId", userId);

                var results = await connection.QueryMultipleAsync("dbo.spGetBookingsByUser", p, commandType: CommandType.StoredProcedure);

                List<Booking> bookings = results.Read<Booking, SelectedFlights, Booking>((booking, flights) =>
                {
                    booking.FlightsDetails = flights;
                    return booking;
                }).ToList();

                List<dynamic> flightIds = results.Read().ToList();

                foreach (var booking in bookings)
                {
                    dynamic flightId = (from i in flightIds
                                       where i.Id == booking.Id
                                       select i).First();

                    booking.FlightsDetails.Outbound = await FindFlightByIdAsync(flightId.OutFlight);
                    booking.FlightsDetails.Inbound = await FindFlightByIdAsync(flightId.InFlight);
                }

                return bookings;
            }
        }

        public Task<Flight> FindFlightByIdAsync(int flightId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            using (IDbConnection connection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@Email", email);

                // Create a null user.
                User user = null;

                try
                {
                    user = await connection.QueryFirstAsync<User>("dbo.spGetUsersByEmail", p, commandType: CommandType.StoredProcedure);

                    // Add user address to User object.
                    user.Address = await FindAddressByIdAsync(user.Id);
                }
                catch (InvalidOperationException)
                {
                    // User not found - null will be returned.
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

        public Task<Staff> FindStaffByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Staff> FindStaffByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Airport>> GetAirportsAsync()
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

        public Task UpdateFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStaffAsync(Staff staff)
        {
            throw new NotImplementedException();
        }
    }
}
