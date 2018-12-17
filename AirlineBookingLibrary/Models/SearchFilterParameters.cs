using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Contains the filters for searches made by a user.
    /// </summary>
    public class SearchFilterParameters
    {
        /// <summary>
        /// The requested origin airport.
        /// </summary>
        public Airport OriginAirport { get; set; }

        /// <summary>
        /// The requested destination airport.
        /// </summary>
        public Airport DestinationAirport { get; set; }

        /// <summary>
        /// The outbound date for the journey.
        /// </summary>
        public DateTime OutDate { get; set; }

        /// <summary>
        /// The inbound date (return) for the journey (can be null if oneway).
        /// </summary>
        public DateTime InDate { get; set; }

        /// <summary>
        /// Whether the journey is return (true) or one way (false).
        /// </summary>
        public bool Return { get; set; }

    }
}
