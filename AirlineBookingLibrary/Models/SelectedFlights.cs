using AirlineBookingLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    public class SelectedFlights : IEquatable<SelectedFlights>
    {
        public Flight Outbound { get; set; }
        public Flight Inbound { get; set; }
        public int NumAdults { get; set; }
        public int NumChildren { get; set; }
        public decimal TotalPrice { get; set; }
        public TravelClass TravelClass { get; set; }
        public bool IsReturn { get; }



        public override bool Equals(object obj)
        {
            return Equals(obj as SelectedFlights);
        }

        public bool Equals(SelectedFlights other)
        {
            return other != null &&
                   EqualityComparer<Flight>.Default.Equals(Outbound, other.Outbound) &&
                   EqualityComparer<Flight>.Default.Equals(Inbound, other.Inbound) &&
                   NumAdults == other.NumAdults &&
                   NumChildren == other.NumChildren &&
                   TotalPrice == other.TotalPrice &&
                   TravelClass == other.TravelClass &&
                   IsReturn == other.IsReturn;
        }

        public override int GetHashCode()
        {
            var hashCode = 319552321;
            hashCode = hashCode * -1521134295 + EqualityComparer<Flight>.Default.GetHashCode(Outbound);
            hashCode = hashCode * -1521134295 + EqualityComparer<Flight>.Default.GetHashCode(Inbound);
            hashCode = hashCode * -1521134295 + NumAdults.GetHashCode();
            hashCode = hashCode * -1521134295 + NumChildren.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
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
