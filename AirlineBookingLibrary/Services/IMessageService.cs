using System.Threading.Tasks;

namespace AirlineBookingLibrary.Services
{
    /// <summary>
    /// Defines methods for sending messages.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Send a message asynchronously.
        /// </summary>
        /// <param name="destination">The destination to send the message to.</param>
        /// <param name="subject">The subject of the message to send.</param>
        /// <param name="body">The main body content of the message.</param>
        /// <returns>An asynchronous task for sending the message.</returns>
        Task SendAsync(string destination, string subject, string body);
    }
}