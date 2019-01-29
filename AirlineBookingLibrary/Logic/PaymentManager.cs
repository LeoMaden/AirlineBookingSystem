using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirlineBookingLibrary.Models;
using AirlineBookingLibrary.Validators;
using FluentValidation.Results;

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
            if (amount <= 0)
            {
                MethodResult paymentFailed = MethodResult.Failed("Amount must be greater than zero");

                return paymentFailed;
            }

            // Validate the payment info provided.
            var paymentInfoValidator = new PaymentInfoValidator();
            ValidationResult paymentValidResult = await paymentInfoValidator.ValidateAsync(paymentInfo);

            if (paymentValidResult.IsValid == false)
            {
                // Convert each ValidationFailure to an error message string and assign to an array. 
                string[] errors = ((List<ValidationFailure>)paymentValidResult.Errors).ConvertAll(x => x.ErrorMessage).ToArray();

                MethodResult paymentFailed = MethodResult.Failed(errors);

                return paymentFailed;
            }

            // Payment info and ammount are valid.
            // Simulate taking a payment.

            return MethodResult.Success;
        }
    }
}
