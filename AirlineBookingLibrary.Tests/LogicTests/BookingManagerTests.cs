﻿using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Logic;
using AirlineBookingLibrary.Models;
using Autofac.Extras.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AirlineBookingLibrary.Tests.LogicTests
{
    public class BookingManagerTests
    {
        [Fact]
        public async void FindBookingsByUserAsync_FindsBookingsForUser()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccess>()
                    .Setup(x =>  x.FindBookingsByUserIdAsync(1))
                    .Returns(Task.Run(() => (ICollection<Booking>)GetSampleBookings()));

                var mockBookingManager = mock.Create<BookingManager>();

                List<Booking> expected = GetSampleBookings();

                List<Booking> actual = (await mockBookingManager.FindBookingsByUserAsync(new User { Id = 1 })).ToList();

                
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async void MakeBookingAsync_MakesBookingCorrectly()
        {
            using (var mock = AutoMock.GetLoose())
            {
                User testUser = new User
                {
                    Id = 42,
                    UserName = "TestUser",
                    Email = "testuser@test.com"
                };

                Booking testBooking = GetSampleBookings().First();


                //mock.Mock<IMessageService>()
                //    .Setup(x => x.SendAsync(testUser.Email,
                //                            Messages.GetBookingConfirmationEmailSubject(testBooking),
                //                            Messages.GetBookingConfirmationEmailBody(testBooking, testUser)))
                //    .Returns(Task.Run(() => MethodResult.Success));

                
            }
        }

        private List<Booking> GetSampleBookings()
        {
            var output = new List<Booking>
            {
                new Booking
                {
                    Id = 12,
                    BookingReference = "AB13F5C1WE",
                    Last4CardDigits = "0154",
                    CardType = "Mastercard",
                    DateTimeCreated = new DateTime(2018, 12, 25, 12, 57, 02),
                    FlightsDetails = new SelectedFlights()
                }
            };

            return output;
        }
    }
}
