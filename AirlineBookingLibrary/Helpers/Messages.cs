using AirlineBookingLibrary.Models;

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
            return "test body";
        }
    }
}
