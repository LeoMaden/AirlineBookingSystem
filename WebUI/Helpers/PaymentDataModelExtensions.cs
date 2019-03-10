using AirlineBookingLibrary.Models;
using System;
using WebUI.Models;

namespace WebUI.Helpers
{
    /// <summary>
    /// Provides extension methods for manipulating PaymentDataModel objects.
    /// </summary>
    public static class PaymentDataModelExtensions
    {
        /// <summary>
        /// Convert this PaymentDataModel to a PaymentInfo object.
        /// </summary>
        /// <param name="paymentData">The PaymentData to convert.</param>
        /// <returns>A PaymentInfo containing the same data.</returns>
        public static PaymentInfo ToPaymentInfo(this PaymentDataModel paymentData)
        {
            DateTime expiration = new DateTime(paymentData.ExipryYear, paymentData.ExpiryMonth, 1);

            var output = new PaymentInfo
            {
                CardNumber = paymentData.CardNumber,
                NameOnCard = paymentData.NameOnCard,
                ExpirationDate = expiration,
                CVV = paymentData.CVV
            };

            return output;
        }
    }
}