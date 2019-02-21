using AirlineBookingLibrary.Data;
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
        // Tests whether the method will use the database connection to retrieve
        // bookings with the given user ID and return the correct values.
        [Fact]
        public async void FindBookingsByUserAsync_FindsBookingsForUser()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Mock an IDataAccess interface so when FindBookingsByUserIdAsync is
                // called, it returns the sample bookings.
                mock.Mock<IDataAccess>()
                    .Setup(x =>  x.FindBookingsByUserIdAsync(1))
                    .Returns(Task.Run(() => (List<Booking>)GetSampleBookings()));

                var mockBookingManager = mock.Create<BookingManager>();

                List<Booking> expected = GetSampleBookings();

                List<Booking> actual = (await mockBookingManager.FindBookingsByUserAsync(new User { Id = 1 })).ToList();

                
                Assert.Equal(expected, actual);
            }
        }

        //// 
        //[Fact]
        //public async void MakeBookingAsync_MakesBookingCorrectly()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        User testUser = new User
        //        {
        //            Id = 42,
        //            UserName = "TestUser",
        //            Email = "testuser@test.com"
        //        };

        //        Booking testBooking = GetSampleBookings().First();


        //        //mock.Mock<IMessageService>()
        //        //    .Setup(x => x.SendAsync(testUser.Email,
        //        //                            Messages.GetBookingConfirmationEmailSubject(testBooking),
        //        //                            Messages.GetBookingConfirmationEmailBody(testBooking, testUser)))
        //        //    .Returns(Task.Run(() => MethodResult.Success));

                
        //    }
        //}


        // Tests that booking references generated are the correct length (10).
        [Fact]
        public async void GenerateBookingReferenceAsync_ReferenceIsCorrectLength()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Booking booking1 = new Booking
                {
                    DateTimeCreated = DateTime.Now,
                    Id = new Random().Next()
                };


                BookingManager bookingManager = mock.Create<BookingManager>();

                string bookingRef = await bookingManager.GenerateBookingReferenceAsync(booking1);

                Assert.Equal(10, bookingRef.Length);
            }
        }

        // Test that the booking reference changes when the Id and/or time created
        // for the booking change.
        [Fact]
        public async void GenerateBookingReferenceAsync_ReferenceChangesBasedOnIdAndDateTimeCreated()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Booking booking1 = new Booking
                {
                    DateTimeCreated = DateTime.Now,
                    Id = 1
                };
                Booking booking2 = new Booking
                {
                    DateTimeCreated = DateTime.Now.AddSeconds(0.5),
                    Id = 1
                };
                Booking booking3 = new Booking
                {
                    DateTimeCreated = DateTime.Now,
                    Id = 3
                };


                BookingManager bookingManager = mock.Create<BookingManager>();

                string ref1 = await bookingManager.GenerateBookingReferenceAsync(booking1);
                string ref2 = await bookingManager.GenerateBookingReferenceAsync(booking2);
                string ref3 = await bookingManager.GenerateBookingReferenceAsync(booking3);

                Assert.True(ref1 != ref2);
                Assert.True(ref1 != ref3);
                Assert.True(ref2 != ref3);
            }
        }
        
        ////[Fact]
        //public async void EmailTest()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        BookingManager bookingManager = mock.Create<BookingManager>();

        //        //await bookingManager.SendBookingConfirmationAsync(new User { Email = "" }, new Booking {
        //        //    FlightsDetails = new SelectedFlights { Outbound = new Flight { OriginAirport = new Airport { FriendlyName = "London Heathrow" } } },
        //        //    BookingReference = "ABC123DEF5"});

        //        Assert.True(false);
        //    }
        //}

        /// <summary>
        /// Get a list that contains sample bookings.
        /// </summary>
        /// <returns>A list of sample booking objects.</returns>
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
