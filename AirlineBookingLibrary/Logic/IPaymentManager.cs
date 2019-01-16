using AirlineBookingLibrary.Models;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Logic
{
    /// <summary>
    /// Defines methods for making payments using a credit card.
    /// </summary>
    public interface IPaymentManager
    {
        /// <summary>
        /// Take the payment using the given card details.
        /// </summary>
        /// <param name="paymentInfo">The card information needed to authorise the payment.</param>
        /// <param name="amount">The amount to take.</param>
        /// <returns>An asynchronous task of MethodResult indicating whether the operation was successful or not.</returns>
        Task<MethodResult> TakePaymentAsync(PaymentInfo paymentInfo, decimal amount);
    }
}
