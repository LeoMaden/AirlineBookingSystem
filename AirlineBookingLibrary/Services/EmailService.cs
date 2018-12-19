using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
