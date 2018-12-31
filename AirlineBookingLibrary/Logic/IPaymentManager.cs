using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Logic
{
    public interface IPaymentManager
    {
        Task<MethodResult> TakePaymentAsync(PaymentInfo paymentInfo, decimal amount);
    }
}
