using System;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Services
{
    public class EmailService : IMessageService
    {
        public Task SendAsync(string destination, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
