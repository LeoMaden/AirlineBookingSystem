using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingLibrary.Models;

namespace AirlineBookingLibrary.Logic
{
    public class PaymentManager : IPaymentManager
    {
        public async Task<MethodResult> TakePaymentAsync(PaymentInfo paymentInfo, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
