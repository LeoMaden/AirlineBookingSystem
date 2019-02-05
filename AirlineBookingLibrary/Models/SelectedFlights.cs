using AirlineBookingLibrary.Enums;
using System;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Contains details about flights selected by a user.
    /// </summary>
    public class SelectedFlights : IEquatable<SelectedFlights>
    {
        public Flight Outbound { get; set; }
        public Flight Inbound { get; set; }
        public int NumberAdults { get; set; }
        public int NumberChildren { get; set; }
        public decimal Price { get; set; }
        public TravelClass TravelClass { get; set; }
        public bool IsReturn
        {
            get
            {
                return Inbound != null;
            }
        }



        public override bool Equals(object obj)
        {
            return Equals(obj as SelectedFlights);
        }

        public bool Equals(SelectedFlights other)
        {
            return other != null &&
                   EqualityComparer<Flight>.Default.Equals(Outbound, other.Outbound) &&
                   EqualityComparer<Flight>.Default.Equals(Inbound, other.Inbound) &&
                   NumberAdults == other.NumberAdults &&
                   NumberChildren == other.NumberChildren &&
                   Price == other.Price &&
                   TravelClass == other.TravelClass &&
                   IsReturn == other.IsReturn;
        }

        public override int GetHashCode()
        {
            var hashCode = 319552321;
            hashCode = hashCode * -1521134295 + EqualityComparer<Flight>.Default.GetHashCode(Outbound);
            hashCode = hashCode * -1521134295 + EqualityComparer<Flight>.Default.GetHashCode(Inbound);
            hashCode = hashCode * -1521134295 + NumberAdults.GetHashCode();
            hashCode = hashCode * -1521134295 + NumberChildren.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + TravelClass.GetHashCode();
            hashCode = hashCode * -1521134295 + IsReturn.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(SelectedFlights flights1, SelectedFlights flights2)
        {
            return EqualityComparer<SelectedFlights>.Default.Equals(flights1, flights2);
        }

        public static bool operator !=(SelectedFlights flights1, SelectedFlights flights2)
        {
            return !(flights1 == flights2);
        }
    }
}
