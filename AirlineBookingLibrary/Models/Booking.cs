using AirlineBookingLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a booking made by a user.
    /// </summary>
    public class Booking : IHasPrimaryKey<int>
    {
        public int Id { get; set; }
        public string BookingReference { get; set; }
        public User User { get; set; }
        public Flight OutFlight { get; set; }
        public Flight InFlight { get; set; }
        public int NumberAdults { get; set; }
        public int NumberChildren { get; set; }
        public TravelClass TravelClass { get; set; }
        public string Last4CardDigits { get; set; }
        public string CardType { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTimeCreated { get; set; }

    }
}
