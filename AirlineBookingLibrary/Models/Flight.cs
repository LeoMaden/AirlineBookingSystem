using System;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a scheduled flight.
    /// </summary>
    public class Flight : IHasPrimaryKey<int>, IEquatable<Flight>
    {
        public int Id { get; set; }

        /// <summary>
        /// The FlightSchedule object that scheduled this flight 
        /// (null if not on a regular schedule).
        /// </summary>
        public FlightSchedule Schedule { get; set; }

        public Airport OriginAirport { get; set; }
        public Airport DestinationAirport { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }




        public override bool Equals(object obj)
        {
            return Equals(obj as Flight);
        }

        public bool Equals(Flight other)
        {
            return other != null &&
                   Id == other.Id &&
                   EqualityComparer<FlightSchedule>.Default.Equals(Schedule, other.Schedule) &&
                   EqualityComparer<Airport>.Default.Equals(OriginAirport, other.OriginAirport) &&
                   EqualityComparer<Airport>.Default.Equals(DestinationAirport, other.DestinationAirport) &&
                   DepartureDateTime == other.DepartureDateTime &&
                   ArrivalDateTime == other.ArrivalDateTime;
        }

        public override int GetHashCode()
        {
            var hashCode = 1326052177;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<FlightSchedule>.Default.GetHashCode(Schedule);
            hashCode = hashCode * -1521134295 + EqualityComparer<Airport>.Default.GetHashCode(OriginAirport);
            hashCode = hashCode * -1521134295 + EqualityComparer<Airport>.Default.GetHashCode(DestinationAirport);
            hashCode = hashCode * -1521134295 + DepartureDateTime.GetHashCode();
            hashCode = hashCode * -1521134295 + ArrivalDateTime.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Flight flight1, Flight flight2)
        {
            return EqualityComparer<Flight>.Default.Equals(flight1, flight2);
        }

        public static bool operator !=(Flight flight1, Flight flight2)
        {
            return !(flight1 == flight2);
        }
    }
}
