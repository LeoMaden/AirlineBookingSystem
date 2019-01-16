using System;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Contains the filter parameters for searches made by a user.
    /// </summary>
    public class SearchFilterParameters : IEquatable<SearchFilterParameters>
    {
        public Airport OriginAirport { get; set; }
        public Airport DestinationAirport { get; set; }
        public DateTime OutDate { get; set; }
        public DateTime InDate { get; set; }

        /// <summary>
        /// Whether the journey is return (true) or one way (false).
        /// </summary>
        public bool Return
        {
            get
            {
                return InDate != new DateTime();
            }
        }



        public override bool Equals(object obj)
        {
            return Equals(obj as SearchFilterParameters);
        }

        public bool Equals(SearchFilterParameters other)
        {
            return other != null &&
                   EqualityComparer<Airport>.Default.Equals(OriginAirport, other.OriginAirport) &&
                   EqualityComparer<Airport>.Default.Equals(DestinationAirport, other.DestinationAirport) &&
                   OutDate == other.OutDate &&
                   InDate == other.InDate &&
                   Return == other.Return;
        }

        public override int GetHashCode()
        {
            var hashCode = 1081298760;
            hashCode = hashCode * -1521134295 + EqualityComparer<Airport>.Default.GetHashCode(OriginAirport);
            hashCode = hashCode * -1521134295 + EqualityComparer<Airport>.Default.GetHashCode(DestinationAirport);
            hashCode = hashCode * -1521134295 + OutDate.GetHashCode();
            hashCode = hashCode * -1521134295 + InDate.GetHashCode();
            hashCode = hashCode * -1521134295 + Return.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(SearchFilterParameters parameters1, SearchFilterParameters parameters2)
        {
            return EqualityComparer<SearchFilterParameters>.Default.Equals(parameters1, parameters2);
        }

        public static bool operator !=(SearchFilterParameters parameters1, SearchFilterParameters parameters2)
        {
            return !(parameters1 == parameters2);
        }
    }
}
