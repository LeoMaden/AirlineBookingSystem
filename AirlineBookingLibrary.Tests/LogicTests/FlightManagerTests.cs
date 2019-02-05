﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Logic;
using AirlineBookingLibrary.Models;
using Autofac.Extras.Moq;
using Moq;
using Xunit;

namespace AirlineBookingLibrary.Tests.LogicTests
{
    public class FlightManagerTests
    {
        [Fact]
        public async void ExistsFlightAsync_DeterminesWhetherFlightExistsCorrectly()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Mock the FindFlightsAsync method of IDataAccess to return an empty List<Flight>
                // on the first call and a populated list on the second call.
                mock.Mock<IDataAccess>()
                    .SetupSequence(x => x.FindFlightsAsync(It.IsAny<Airport>(), It.IsAny<Airport>(), It.IsAny<DateTime>()))
                    .ReturnsAsync(new List<Flight>())
                    .ReturnsAsync(new List<Flight> { new Flight(), new Flight() });

                FlightManager flightManager = mock.Create<FlightManager>();

                bool expected1 = false;
                bool expected2 = true;

                bool actual1 = await flightManager.ExistsFlightAsync(new Airport(), new Airport(), DateTime.Now);
                bool actual2 = await flightManager.ExistsFlightAsync(new Airport(), new Airport(), DateTime.Now);

                Assert.Equal(expected1, actual1);
                Assert.Equal(expected2, actual2);
            }
        }

        [Fact]
        public async void FindCheapestInboundFlightAsync_FindsCheapestFlight()
        {
            List<Flight> flights = GetFlights().ToList();


            // Mock the flight price calculator class to return specified values for each
            // call of CalculateBasePriceAsync regardless of what flight is passed.
            var flightPriceCalcMock = new Mock<FlightPriceCalculator>();

            flightPriceCalcMock
                .SetupSequence(x => x.CalculateBasePriceAsync(It.IsAny<Flight>()))
                .ReturnsAsync(500)
                .ReturnsAsync(200)
                .ReturnsAsync(100)
                .ReturnsAsync(120);


            // Mock an IDataAccess interface with no implementation of methods as
            // they are not required in this test.
            var dataAccessMock = new Mock<IDataAccess>();


            // Mock the FlightManager class, instantiating it with the mocked IDataAccess and 
            // FlightPriceCalculator objects, to return the list of flights declared above
            // whenever FindInboundFlightsAsync is called with any SearchFilterParameters.
            var flightManagerMock = new Mock<FlightManager>(dataAccessMock.Object, flightPriceCalcMock.Object)
            {
                CallBase = true
            };

            flightManagerMock
                .Setup(x => x.FindInboundFlightsAsync(It.IsAny<SearchFilterParameters>()))
                .ReturnsAsync(flights);


            // Expected cheapest flight is the 3rd flight.
            Flight expected = flights[2];

            Flight actual = await flightManagerMock.Object.FindCheapestInboundFlightAsync(new SearchFilterParameters());

            Assert.Equal(expected, actual);
        }



        private ICollection<Flight> GetFlights()
        {
            var output = new List<Flight>
            {
                new Flight
                {
                    OriginAirport = new Airport { AirportCode = "LHR" },
                    DestinationAirport = new Airport { AirportCode = "MAN" },
                    DepartureDateTime = DateTime.Now.AddDays(10)
                },
                new Flight
                {
                    OriginAirport = new Airport { AirportCode = "LGW" },
                    DestinationAirport = new Airport { AirportCode = "AMS" },
                    DepartureDateTime = DateTime.Now.AddDays(9)
                },
                new Flight
                {
                    OriginAirport = new Airport { AirportCode = "INN" },
                    DestinationAirport = new Airport { AirportCode = "MUC" },
                    DepartureDateTime = DateTime.Now.AddDays(11)
                },
                new Flight
                {
                    OriginAirport = new Airport { AirportCode = "JFK" },
                    DestinationAirport = new Airport { AirportCode = "LAX" },
                    DepartureDateTime = DateTime.Now.AddDays(8)
                }
            };

            return output;
        }
    }
}