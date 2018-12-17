using AirlineBookingLibrary.Models;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Data
{
    public interface IDataAccess
    {
        User CreateUser(User user);
        Booking CreateBooking(Booking booking);
        Staff CreateStaff(Staff staff);

        void EditUser(User user);
        void EditBooking(Booking booking);

        List<Airport> GetAirports();
        List<FlightSchedule> GetFlightSchedule();
        List<Flight> GetAllFlights();
        List<Flight> GetFlights(SearchFilterParameters filters);
        User GetUser(int userID);
        List<Booking> GetBookings(User user);
    }
}