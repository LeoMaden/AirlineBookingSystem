using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Logic
{
    public interface IBookingManager
    {
        Task<MethodResult> MakeBookingAsync(User user, SelectedFlights selectedFlights, PaymentInfo paymentInfo);
        Task<IEnumerable<Booking>> FindBookingsByUserAsync(User user);
        Task SendBookingConfirmationAsync(User user, Booking booking);
    }
}
