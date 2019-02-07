using AirlineBookingLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Logic
{
    /// <summary>
    /// Defines methods for managing user bookings.
    /// </summary>
    public interface IBookingManager
    {
        /// <summary>
        /// Make a booking and take payment from a user.
        /// </summary>
        /// <param name="user">The user that is making the booking.</param>
        /// <param name="selectedFlights">The flight(s) the user is booking.</param>
        /// <param name="paymentInfo">The user's card details to pay for the flights.</param>
        /// <returns>An asynchronous task of MethodResult indicating whether the operation was successful or not.</returns>
        Task<MethodResult> MakeBookingAsync(User user, SelectedFlights selectedFlights, PaymentInfo paymentInfo);

        /// <summary>
        /// Find the previous bookings made by a user.
        /// </summary>
        /// <param name="user">The user whose bookings to find.</param>
        /// <returns>An asynchronous task of the user's bookings.</returns>
        Task<IEnumerable<Booking>> FindBookingsByUserAsync(User user);

        /// <summary>
        /// Send the user a confirmation email for their booking.
        /// </summary>
        /// <param name="user">The user that made the booking.</param>
        /// <param name="booking">The booking that was made.</param>
        /// <returns>An asynchronous task for sending the confirmation email.</returns>
        Task SendBookingConfirmationAsync(User user, Booking booking);

        /// <summary>
        /// Generate the unique booking reference for this booking.
        /// </summary>
        /// <param name="booking">The booking to generate the reference for.</param>
        /// <returns>The asynchronous task for calculating the booking reference.</returns>
        Task<string> GenerateBookingReferenceAsync(Booking booking);
    }
}
