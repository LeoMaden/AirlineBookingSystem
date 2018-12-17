using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a scheduled flight.
    /// </summary>
    public class Flight : IHasPrimaryKey<int>
    {
        /// <summary>
        /// The unique ID for this flight.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The flight number of this flight.
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// The origin of this flight.
        /// </summary>
        public Airport OriginAirport { get; set; }

        /// <summary>
        /// The destination of this flight.
        /// </summary>
        public Airport DestinationAirport { get; set; }

        /// <summary>
        /// The time when this flight departs the origin airport.
        /// </summary>
        public DateTime DepartureDateTime { get; set; }

        /// <summary>
        /// The time when this flight arrives at the destination airport.
        /// </summary>
        public DateTime ArrivalDateTime { get; set; }

    }
}
