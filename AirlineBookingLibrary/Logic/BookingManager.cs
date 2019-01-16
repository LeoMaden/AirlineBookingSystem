using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Models;
using AirlineBookingLibrary.Services;

namespace AirlineBookingLibrary.Logic
{
    /// <summary>
    /// Implementation of the IBookingManager interface to manage
    /// user bookings.
    /// </summary>
    public class BookingManager : IBookingManager
    {
        /// <summary>
        /// The IDataAccess used to retrieve information.
        /// </summary>
        private readonly IDataAccess _dataAccess;

        /// <summary>
        /// The IPaymentManager used to manage payments.
        /// </summary>
        private readonly IPaymentManager _paymentManager;

        /// <summary>
        /// The IMessageService used for sending confirmation emails.
        /// </summary>
        private readonly IMessageService _messageService;


        /// <summary>
        /// Create a new instance of the BookingManager class using the given
        /// IDataAccess, IPaymentManager, and IMessageService.
        /// </summary>
        /// <param name="dataAccess">The IDataAccess for this class to use.</param>
        /// <param name="paymentManager">The IPaymentManager for this class to use.</param>
        /// <param name="messageService">The IMessageService for this class to use.</param>
        public BookingManager(IDataAccess dataAccess, IPaymentManager paymentManager, IMessageService messageService)
        {
            _dataAccess = dataAccess;
            _paymentManager = paymentManager;
            _messageService = messageService;
        }



        /// <summary>
        /// Find the previous bookings made by a user.
        /// </summary>
        /// <param name="user">The user whose bookings to find.</param>
        /// <returns>An asynchronous task of the user's bookings.</returns>
        public async Task<IEnumerable<Booking>> FindBookingsByUserAsync(User user)
        {
            return await _dataAccess.FindBookingsByUserIdAsync(user.Id);
        }

        /// <summary>
        /// Make a booking and take payment from a user.
        /// </summary>
        /// <param name="user">The user that is making the booking.</param>
        /// <param name="selectedFlights">The flight(s) the user is booking.</param>
        /// <param name="paymentInfo">The user's card details to pay for the flights.</param>
        /// <returns>An asynchronous task of MethodResult indicating whether the operation was successful or not.</returns>
        public async Task<MethodResult> MakeBookingAsync(User user, SelectedFlights selectedFlights, PaymentInfo paymentInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send the user a confirmation email for their booking.
        /// </summary>
        /// <param name="user">The user that made the booking.</param>
        /// <param name="booking">The booking that was made.</param>
        /// <returns>An asynchronous task for sending the confirmation email.</returns>
        public async Task SendBookingConfirmationAsync(User user, Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
