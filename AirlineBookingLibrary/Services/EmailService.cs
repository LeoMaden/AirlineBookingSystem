using System;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Services
{
    /// <summary>
    /// An implementation of IMessageService that sends messages
    /// via an email.
    /// </summary>
    public class EmailService : IMessageService
    {
        /// <summary>
        /// Send an email asynchronously.
        /// </summary>
        /// <param name="destination">The email address to send the email to.</param>
        /// <param name="subject">The subject of the email to send.</param>
        /// <param name="body">The main body content of the email.</param>
        /// <returns>An asynchronous task for sending the email.</returns>
        public Task SendAsync(string destination, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
