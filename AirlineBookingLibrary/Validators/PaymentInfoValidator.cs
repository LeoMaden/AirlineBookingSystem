using AirlineBookingLibrary.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Validators
{
    public class PaymentInfoValidator : AbstractValidator<PaymentInfo>
    {
        public PaymentInfoValidator()
        {
            RuleFor(x => x.NameOnCard)
                .NotNull()
                .Must(BeAValidName);

            RuleFor(x => x.CardNumber)
                .CreditCard();

            RuleFor(x => x.ExpirationDate)
                .GreaterThan(DateTime.Today);

            RuleFor(x => x.CVV)
                .Length(3)
                .Must(ContainDigitsOnly);
        }

        private bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");

            return name.All(Char.IsLetter);
        }

        private bool ContainDigitsOnly(string str)
        {
            return str.All(Char.IsDigit);
        }
    }
}
