using System;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents an airport.
    /// </summary>
    public class Airport : IHasPrimaryKey<int>, IEquatable<Airport>
    {
        public int Id { get; set; }
        public string AirportCode { get; set; }
        public string FriendlyName { get; set; }



        public override bool Equals(object obj)
        {
            return Equals(obj as Airport);
        }

        public bool Equals(Airport other)
        {
            return other != null &&
                   Id == other.Id &&
                   AirportCode == other.AirportCode &&
                   FriendlyName == other.FriendlyName;
        }

        public override int GetHashCode()
        {
            var hashCode = 2128963242;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AirportCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FriendlyName);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{ AirportCode }, { FriendlyName }";
        }

        public static bool operator ==(Airport airport1, Airport airport2)
        {
            return EqualityComparer<Airport>.Default.Equals(airport1, airport2);
        }

        public static bool operator !=(Airport airport1, Airport airport2)
        {
            return !(airport1 == airport2);
        }
    }
}
