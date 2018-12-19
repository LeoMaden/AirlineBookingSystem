using System;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a flight that is scheduled each week.
    /// </summary>
    public class FlightSchedule : IHasPrimaryKey<int>
    {
        public int Id { get; set; }
        public string RouteCode { get; set; }
        public Airport OriginAirport { get; set; }
        public Airport DestinationAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

    }
}