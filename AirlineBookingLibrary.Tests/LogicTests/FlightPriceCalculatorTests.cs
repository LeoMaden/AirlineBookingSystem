using AirlineBookingLibrary.Enums;
using AirlineBookingLibrary.Logic;
using AirlineBookingLibrary.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AirlineBookingLibrary.Tests.LogicTests
{
    public class FlightPriceCalculatorTests
    {
        // Test that the method will calculate the correct base price
        // of a flight.
        [Theory]
        [MemberData(nameof(GetFlightPriceData))]
        public async void CalculateBasePriceAsync_CalculatesCorrectBasePrice(Flight flight, decimal expectedPrice)
        {
            var calculator = new FlightPriceCalculator();

            decimal actualPrice = await calculator.CalculateBasePriceAsync(flight);

            Assert.Equal(expectedPrice, actualPrice);
        }

        // Test that the method will calculate the correct total price for the
        // flights, travel class, and number of passengers.
        [Theory]
        [MemberData(nameof(GetTotalPriceData))]
        public async void CalculateTotalPriceAsync_CalculatesCorrectTotalPrice(TravelClass travelClass, int numAdults, int numChildren, decimal expectedPrice)
        {
            Mock<FlightPriceCalculator> mock = new Mock<FlightPriceCalculator>();
            mock.SetupSequence(x => x.CalculateBasePriceAsync(It.IsAny<Flight>()))
                .ReturnsAsync(100M)
                .ReturnsAsync(150M);

            var calculator = mock.Object;

            SelectedFlights selectedFlights = new SelectedFlights()
            {
                Outbound = new Flight(),
                Inbound = new Flight(),
                TravelClass = travelClass,
                NumberAdults = numAdults,
                NumberChildren = numChildren
            };

            decimal actualPrice = await calculator.CalculateTotalPriceAsync(selectedFlights);


            // Check expected and actual prices match.
            Assert.Equal(expectedPrice, actualPrice);

            // Check that TotalPrice property is set in selectedFlights
            Assert.True(selectedFlights.Price == expectedPrice);
            
            
        }
        


        /// <summary>
        /// Get flight objects and their corresponding price.
        /// </summary>
        /// <returns>A List<object[]> where the object[] contains { flight, price }.</returns>
        public static List<object[]> GetFlightPriceData()
        {
            // Expected price calculated by:
            // Base + (per mile rate * distance) rounded up to £5
            // Flights booked on the day are 3x the regular price.
            // Flights booked within the week before are 1.5x the regular price.

            List<object[]> flights = new List<object[]>();


            // LHR -> JFK, in 14 days.
            Flight flight1 = new Flight()
            {
                OriginAirport = new Airport() { AirportCode = "LHR", FriendlyName = "London Heathrow" },
                DestinationAirport = new Airport() { AirportCode = "JFK", FriendlyName = "John F. Kennedy International Airport" },
                DepartureDateTime = DateTime.Now.AddDays(14)
            };

            // 50 + (0.15 * 3451) rounded up to £5
            decimal price1 = 570;

            flights.Add(new object[] { flight1, price1 });


            // BUD -> AMS, in 7 days.
            Flight flight2 = new Flight()
            {
                OriginAirport = new Airport() { AirportCode = "BUD", FriendlyName = "Budapest Ferenc Liszt International Airport" },
                DestinationAirport = new Airport() { AirportCode = "AMS", FriendlyName = "Amsterdam Schiphol Airport" },
                DepartureDateTime = DateTime.Now.AddDays(7)
            };

            // [50 + (0.15 * 728)] * 1.5 rounded up to £5
            decimal price2 = 240;

            flights.Add(new object[] { flight2, price2 });


            // STN -> INN, today.
            Flight flight3 = new Flight()
            {
                OriginAirport = new Airport() { AirportCode = "STN", FriendlyName = "London Stansted Airport" },
                DestinationAirport = new Airport() { AirportCode = "INN", FriendlyName = "Innsbruck Airport" },
                DepartureDateTime = DateTime.Now.AddHours(2)
            };

            // [50 + (0.15 * 592)] * 3 rounded up to £5
            decimal price3 = 420;

            flights.Add(new object[] { flight3, price3 });


            return flights;
        }

        /// <summary>
        /// Get price data based on TravelClass, number of adults, and number
        /// of children. To be used in CalculateTotalPriceAsync_CalculatesCorrectTotalPrice
        /// test method.
        /// </summary>
        /// <returns>A List of the data in the form { TravelClass, numAdults, numChildren, expectedPrice }.</returns>
        public static List<object[]> GetTotalPriceData()
        {
            List<object[]> output = new List<object[]>();

            // 100 for outbound + 150 for inbound = 250
            output.Add(new object[] { TravelClass.Economy, 1, 0, 250 });

            // [100 + (100 * 0.6)] for outbound + [150 + (150 * 0.6)] for inbound = 400
            output.Add(new object[] { TravelClass.Economy, 1, 1, 400 });

            // [(2 * 100) + (100 * 0.6)] * 5 for outbound + [(2 * 150) + (150 * 0.6)] * 5 for inbound = 3250
            output.Add(new object[] { TravelClass.First, 2, 1, 3250 });

            return output;
        }
    }
}
