using AirlineBookingLibrary.Logic;
using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AirlineBookingLibrary.Tests.LogicTests
{
    public class PaymentManagerTests
    {
        [Theory]
        [MemberData(nameof(GetTakePaymentFailureData))]
        public async void TakePaymentAsync_ReturnsFailureWhenPaymentInfoIsInvalid(string nameOnCard, string cardNumber, DateTime expirationDate, string cvv)
        {
            PaymentManager paymentManager = new PaymentManager();

            PaymentInfo paymentInfo = new PaymentInfo()
            {
                NameOnCard = nameOnCard,
                CardNumber = cardNumber,
                ExpirationDate = expirationDate,
                CVV = cvv
            };

            MethodResult actualResult = await paymentManager.TakePaymentAsync(paymentInfo, 10);

            Assert.True(actualResult.Succeeded == false);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public async void TakePaymentAsync_ReturnsFailureWhenAmountIsInvalid(decimal amount)
        {
            PaymentManager paymentManager = new PaymentManager();

            PaymentInfo paymentInfo = new PaymentInfo()
            {
                NameOnCard = "Test User",
                CardNumber = "5555555555554444",
                ExpirationDate = DateTime.Now.AddYears(2),
                CVV = "123"
            };

            MethodResult actualResult = await paymentManager.TakePaymentAsync(paymentInfo, amount);

            Assert.True(actualResult.Succeeded == false);
        }

        [Fact]
        public async void TakePaymentAsync_ReturnsSuccessWhenValidValuesPassed()
        {
            PaymentManager paymentManager = new PaymentManager();

            PaymentInfo paymentInfo = new PaymentInfo()
            {
                NameOnCard = "Test User",
                CardNumber = "5555555555554444",
                ExpirationDate = DateTime.Now.AddYears(2),
                CVV = "123"
            };

            MethodResult actualResult = await paymentManager.TakePaymentAsync(paymentInfo, 10);

            Assert.True(actualResult.Succeeded == true);
        }




        public static List<object[]> GetTakePaymentFailureData()
        {
            List<object[]> output = new List<object[]>();

            // Invalid nameOnCard.
            output.Add(new object[] { "1234", "5555555555554444", DateTime.Now.AddYears(2), "123" });
            output.Add(new object[] { "", "5555555555554444", DateTime.Now.AddYears(2), "123" });

            // Invalid cardNumber
            output.Add(new object[] { "Test User", "121", DateTime.Now.AddYears(2), "123" });
            output.Add(new object[] { "Test User", "aaaabbbbccccdddd", DateTime.Now.AddYears(2), "123" });
            output.Add(new object[] { "Test User", "1234123456785678", DateTime.Now.AddYears(2), "123" });

            // Invalid expiry.
            output.Add(new object[] { "Test User", "5555555555554444", DateTime.Now.AddYears(-1), "123" });

            // Invalid CVV.
            output.Add(new object[] { "Test User", "5555555555554444", DateTime.Now.AddYears(2), "1" });
            output.Add(new object[] { "Test User", "5555555555554444", DateTime.Now.AddYears(2), "abc" });

            return output;
        }
        
    }
}
