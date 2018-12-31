using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Services
{
    public interface IMessageService
    {
        Task SendAsync(string destination, string subject, string body);
    }
}