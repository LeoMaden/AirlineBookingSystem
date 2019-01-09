using System;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a user's address.
    /// </summary>
    public class Address : IEquatable<Address>
    {
        public string StreetAddress { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }



        public override bool Equals(object obj)
        {
            return Equals(obj as Address);
        }

        public bool Equals(Address other)
        {
            return other != null &&
                   StreetAddress == other.StreetAddress &&
                   Locality == other.Locality &&
                   City == other.City &&
                   Postcode == other.Postcode;
        }

        public override int GetHashCode()
        {
            var hashCode = 1558844050;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StreetAddress);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Locality);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Postcode);
            return hashCode;
        }

        public static bool operator ==(Address address1, Address address2)
        {
            return EqualityComparer<Address>.Default.Equals(address1, address2);
        }

        public static bool operator !=(Address address1, Address address2)
        {
            return !(address1 == address2);
        }
    }
}
