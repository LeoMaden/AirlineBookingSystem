using System;

namespace AirlineBookingLibrary.Models
{
    public class FlightSchedule
    {
        public int RouteID { get; set; }

        public string RouteCode { get; set; }

        public Airport OriginAirport { get; set; }

        public Airport DestinationAirport { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

    }
}