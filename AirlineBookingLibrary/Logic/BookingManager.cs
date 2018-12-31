using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Models;
using AirlineBookingLibrary.Services;

namespace AirlineBookingLibrary.Logic
{
    public class BookingManager : IBookingManager
    {
        private readonly IDataAccess _dataAccess;
        private readonly IPaymentManager _paymentManager;
        private readonly IMessageService _messageService;


        public BookingManager(IDataAccess dataAccess, IPaymentManager paymentManager, IMessageService messageService)
        {
            _dataAccess = dataAccess;
            _paymentManager = paymentManager;
            _messageService = messageService;
        }


        public async Task<IEnumerable<Booking>> FindBookingsByUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<MethodResult> MakeBookingAsync(User user, SelectedFlights selectedFlights, PaymentInfo paymentInfo)
        {
            throw new NotImplementedException();
        }

        public async Task SendBookingConfirmationAsync(User user, Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
