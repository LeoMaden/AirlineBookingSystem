using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Data
{
    /// <summary>
    /// Defines methods for creating, updating, retrieving, and deleting
    /// data from a persistant storage location.
    /// </summary>
    public interface IDataAccess
    {
        //
        // User data access.
        Task CreateAsync(User user);
        Task CreateAddressAsync(User user);

        Task DeleteAsync(User user);
        Task DeleteAddressAsync(User user);

        Task<User> FindByEmailAsync(string email);

        Task<User> FindByIdAsync(int userId);
        Task<Address> FindAddressByIdAsync(int userId);

        Task<User> FindByNameAsync(string userName);

        Task UpdateAsync(User user);
        Task UpdateAddressAsync(User user);

        //
        // Booking data access.
        Task<List<Booking>> FindBookingsByUserIdAsync(int userId);
        Task CreateBookingAsync(Booking booking, User user);

        //
        // Flight data access.
        Task CreateFlightAsync(Flight flight);
        Task DeleteFlightAsync(Flight flight);
        Task UpdateFlightAsync(Flight flight);
        Task<List<Flight>> FindFlightsAsync(Airport origin, Airport destination, DateTime date);
        Task<Flight> FindFlightByIdAsync(int flightId);

        //
        // Schedule data access.
        Task<FlightSchedule> FindScheduleByIdAsync(int scheduleId);

        //
        // Airport data access.
        Task<List<Airport>> GetAirportsAsync();
        Task<Airport> FindAirportByIdAsync(int airportId);

        //
        // Staff data access.
        Task CreateStaffAsync(Staff staff);
        Task DeleteStaffAsync(Staff staff);
        Task UpdateStaffAsync(Staff staff);

        Task<Staff> FindStaffByIdAsync(int id);

        Task<Staff> FindStaffByNameAsync(string userName);
    }
}