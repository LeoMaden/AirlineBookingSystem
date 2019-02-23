using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.Helpers
{
    public static class PaymentDataModelExtensions
    {
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