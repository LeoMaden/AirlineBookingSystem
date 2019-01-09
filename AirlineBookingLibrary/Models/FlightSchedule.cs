using System;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a flight that is scheduled each week.
    /// </summary>
    public class FlightSchedule : IHasPrimaryKey<int>, IEquatable<FlightSchedule>
    {
        public int Id { get; set; }
        public string RouteCode { get; set; }
        public Airport OriginAirport { get; set; }
        public Airport DestinationAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }



        public override bool Equals(object obj)
        {
            return Equals(obj as FlightSchedule);
        }

        public bool Equals(FlightSchedule other)
        {
            return other != null &&
                   Id == other.Id &&
                   RouteCode == other.RouteCode &&
                   EqualityComparer<Airport>.Default.Equals(OriginAirport, other.OriginAirport) &&
                   EqualityComparer<Airport>.Default.Equals(DestinationAirport, other.DestinationAirport) &&
                   DepartureTime == other.DepartureTime &&
                   ArrivalTime == other.ArrivalTime &&
                   DayOfWeek == other.DayOfWeek;
        }

        public override int GetHashCode()
        {
            var hashCode = -1474620316;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RouteCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<Airport>.Default.GetHashCode(OriginAirport);
            hashCode = hashCode * -1521134295 + EqualityComparer<Airport>.Default.GetHashCode(DestinationAirport);
            hashCode = hashCode * -1521134295 + DepartureTime.GetHashCode();
            hashCode = hashCode * -1521134295 + ArrivalTime.GetHashCode();
            hashCode = hashCode * -1521134295 + DayOfWeek.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(FlightSchedule schedule1, FlightSchedule schedule2)
        {
            return EqualityComparer<FlightSchedule>.Default.Equals(schedule1, schedule2);
        }

        public static bool operator !=(FlightSchedule schedule1, FlightSchedule schedule2)
        {
            return !(schedule1 == schedule2);
        }
    }
}