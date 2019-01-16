using System;
using System.Threading.Tasks;
using AirlineBookingLibrary.Models;

namespace AirlineBookingLibrary.Logic
{
    /// <summary>
    /// An implementation of the IPaymentManager interface.
    /// </summary>
    public class PaymentManager : IPaymentManager
    {
        /// <summary>
        /// Take the payment using the given card details.
        /// </summary>
        /// <param name="paymentInfo">The card information needed to authorise the payment.</param>
        /// <param name="amount">The amount to take.</param>
        /// <returns>An asynchronous task of MethodResult indicating whether the operation was successful or not.</returns>
        public async Task<MethodResult> TakePaymentAsync(PaymentInfo paymentInfo, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
