using System;
using System.Collections.Generic;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a booking made by a user.
    /// </summary>
    public class Booking : IHasPrimaryKey<int>, IEquatable<Booking>
    {
        public int Id { get; set; }
        public string BookingReference { get; set; }
        public string Last4CardDigits { get; set; }
        public string CardType { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public SelectedFlights FlightsDetails { get; set; }



        public override bool Equals(object obj)
        {
            return Equals(obj as Booking);
        }

        public bool Equals(Booking other)
        {
            return other != null &&
                   Id == other.Id &&
                   BookingReference == other.BookingReference &&
                   Last4CardDigits == other.Last4CardDigits &&
                   CardType == other.CardType &&
                   DateTimeCreated == other.DateTimeCreated &&
                   EqualityComparer<SelectedFlights>.Default.Equals(FlightsDetails, other.FlightsDetails);
        }

        public override int GetHashCode()
        {
            var hashCode = 895644725;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BookingReference);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Last4CardDigits);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CardType);
            hashCode = hashCode * -1521134295 + DateTimeCreated.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<SelectedFlights>.Default.GetHashCode(FlightsDetails);
            return hashCode;
        }

        public static bool operator ==(Booking booking1, Booking booking2)
        {
            return EqualityComparer<Booking>.Default.Equals(booking1, booking2);
        }

        public static bool operator !=(Booking booking1, Booking booking2)
        {
            return !(booking1 == booking2);
        }
    }
}
