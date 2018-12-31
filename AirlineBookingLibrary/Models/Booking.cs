using AirlineBookingLibrary.Enums;
using System;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a booking made by a user.
    /// </summary>
    public class Booking : IHasPrimaryKey<int>
    {
        public int Id { get; set; }
        public string BookingReference { get; set; }
        public string Last4CardDigits { get; set; }
        public string CardType { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public SelectedFlights FlightsDetails { get; set; }


    }
}
