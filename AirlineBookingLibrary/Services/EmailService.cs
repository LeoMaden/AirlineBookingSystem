using System.Net.Mail;
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
        public async Task SendAsync(string destination, string subject, string body)
        {
            MailAddress senderEmail = new MailAddress("britishairwaysproject@gmail.com", "British Airways Project");
            MailAddress recipientEmail = new MailAddress(destination);

            MailMessage mail = new MailMessage(senderEmail, recipientEmail);
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            
            mail.Subject = subject;
            mail.Body = body;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("britishairwaysproject@gmail.com", "kHDmiK@88x6v");
            SmtpServer.EnableSsl = true;

            await SmtpServer.SendMailAsync(mail);
        }
    }
}
