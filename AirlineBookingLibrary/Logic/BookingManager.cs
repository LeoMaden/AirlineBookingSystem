using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Models;
using AirlineBookingLibrary.Services;
using AirlineBookingLibrary.Helpers;

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
        /// Generate the unique 10 digit long booking reference for this booking.
        /// </summary>
        /// <param name="booking">The booking to generate the reference for.</param>
        /// <returns>The asynchronous task for calculating the booking reference.</returns>
        public async Task<string> GenerateBookingReferenceAsync(Booking booking)
        {
            // Define the length of the booking reference.
            const int length = 10;

            // Get byte[]s for the DateTimeCreated and Id fields.
            byte[] dateBytes = Encoding.ASCII.GetBytes(booking.DateTimeCreated.ToBinary().ToString());
            byte[] idBytes = Encoding.ASCII.GetBytes(booking.Id.ToString());

            // Join byte[]s together.
            byte[] totalBytes = dateBytes.Concat(idBytes).ToArray();

            using (SHA256 hasher = SHA256.Create())
            {
                // Hash the totalBytes.
                byte[] hashResult = hasher.ComputeHash(totalBytes);

                // Convert the hash to a string.
                string hashString = Convert.ToBase64String(hashResult);

                // Remove + and / characters and make all letters uppercase.
                string base36HashString = hashString.Replace("+", "").Replace("/", "").ToUpper();

                // Take the first n bits of the base 36 hash string.
                string bookingRef = base36HashString.Substring(0, length);


                booking.BookingReference = bookingRef;

                return bookingRef;
            }
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
            decimal price = selectedFlights.Price;

            var paymentResult = await _paymentManager.TakePaymentAsync(paymentInfo, price);

            if (paymentResult.Succeeded == false)
            {
                return MethodResult.Failed(paymentResult.Errors.ToArray());
            }

            // Payment succeeded - create booking.
            Booking newBooking = new Booking
            {
                Last4CardDigits = paymentInfo.CardNumber.Substring(11, 4),
                CardType = await _paymentManager.GetCardIssuerAsync(paymentInfo.CardNumber),
                DateTimeCreated = DateTime.Now,
                FlightsDetails = selectedFlights
            };

            // Generate the booking reference.
            await GenerateBookingReferenceAsync(newBooking);

            // Crate booking in database.
            await _dataAccess.CreateBookingAsync(newBooking, user);

            // Send confirmation email.
            await SendBookingConfirmationAsync(user, newBooking);

            return MethodResult.Success;
        }

        /// <summary>
        /// Send the user a confirmation email for their booking.
        /// </summary>
        /// <param name="user">The user that made the booking.</param>
        /// <param name="booking">The booking that was made.</param>
        /// <returns>An asynchronous task for sending the confirmation email.</returns>
        public async Task SendBookingConfirmationAsync(User user, Booking booking)
        {
            string destination = user.Email;
            string subject = Messages.GetBookingConfirmationEmailSubject(booking);
            string body = Messages.GetBookingConfirmationEmailBody(booking, user);

            await _messageService.SendAsync(destination, subject, body);

        }
    }
}
