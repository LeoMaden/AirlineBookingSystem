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
        /// <summary>
        /// The unique ID of this booking.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The unique booking reference code for this booking.
        /// </summary>
        public string BookingReference { get; set; }

        /// <summary>
        /// The user that created this booking.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// The outbound flight booked.
        /// </summary>
        public Flight OutFlight { get; set; }

        /// <summary>
        /// The inbound flight booked (can be null if one way).
        /// </summary>
        public Flight InFlight { get; set; }

        /// <summary>
        /// The number of adults on this booking.
        /// </summary>
        public int NumberAdults { get; set; }

        /// <summary>
        /// The number of children on this booking.
        /// </summary>
        public int NumberChildren { get; set; }

        /// <summary>
        /// The travel class for this booking.
        /// </summary>
        public TravelClass TravelClass { get; set; }

        /// <summary>
        /// The last 4 digits of the payment card used for this booking.
        /// </summary>
        public string Last4CardDigits { get; set; }

        /// <summary>
        /// The type of card used for this booking (Visa, Mastercard, etc.)
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// The price of this booking.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The date and time this booking was created.
        /// </summary>
        public DateTime DateTimeCreated { get; set; }

    }
}
