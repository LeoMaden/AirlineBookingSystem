using System;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a scheduled flight.
    /// </summary>
    public class Flight : IHasPrimaryKey<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// The FlightSchedule object that scheduled this flight (null if not on a regular schedule).
        /// </summary>
        public FlightSchedule Schedule { get; set; }

        public Airport OriginAirport { get; set; }
        public Airport DestinationAirport { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }

    }
}
