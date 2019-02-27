using AirlineBookingLibrary.Models;
using System.Text;

namespace AirlineBookingLibrary.Helpers
{
    /// <summary>
    /// Contains static methods for getting commonly used messages 
    /// such as email subject or content.
    /// </summary>
    public static class Messages
    {
        public static string GetBookingConfirmationEmailSubject(Booking booking)
        {
            return $"Your British Airways Booking to { booking.FlightsDetails.Outbound.DestinationAirport.FriendlyName } - Ref: { booking.BookingReference }.";
        }

        public static string GetBookingConfirmationEmailBody(Booking booking, User user)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"Thank you for your order, { user.FirstName }...");
            message.AppendLine();

            message.AppendLine("Outbound:");
            message.Append($"{ booking.FlightsDetails.Outbound.OriginAirport } {booking.FlightsDetails.Outbound.DepartureDateTime.ToString("(ddd dd MMM yy)") }");
            message.Append($" -> ");
            message.Append($"{ booking.FlightsDetails.Outbound.DestinationAirport } {booking.FlightsDetails.Outbound.ArrivalDateTime.ToString("(ddd dd MMM yy)") }");
            message.AppendLine();

            if (booking.FlightsDetails.IsReturn)
            {
                message.AppendLine("Inbound:");
                message.Append($"{ booking.FlightsDetails.Inbound.OriginAirport } {booking.FlightsDetails.Inbound.DepartureDateTime.ToString("(ddd dd MMM yy)") }");
                message.Append($" -> ");
                message.Append($"{ booking.FlightsDetails.Inbound.DestinationAirport } {booking.FlightsDetails.Inbound.ArrivalDateTime.ToString("(ddd dd MMM yy)") }");
                message.AppendLine();
            }

            message.AppendLine($"Adults: { booking.FlightsDetails.NumberAdults }");
            message.AppendLine($"Children: { booking.FlightsDetails.NumberChildren }");
            message.AppendLine($"Class: { booking.FlightsDetails.TravelClass }");
            message.AppendLine();

            message.AppendLine($"Price: { booking.FlightsDetails.Price.ToString("C") }");

            return message.ToString();
        }
    }
}
