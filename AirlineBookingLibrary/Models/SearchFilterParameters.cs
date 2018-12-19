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
        public Airport OriginAirport { get; set; }
        public Airport DestinationAirport { get; set; }
        public DateTime OutDate { get; set; }
        public DateTime InDate { get; set; }

        /// <summary>
        /// Whether the journey is return (true) or one way (false).
        /// </summary>
        public bool Return { get; set; }

    }
}
