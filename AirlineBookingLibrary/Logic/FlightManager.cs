using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Models;

namespace AirlineBookingLibrary.Logic
{
    /// <summary>
    /// An implementation of the IFlightManager interface to retrieve 
    /// flight information.
    /// </summary>
    public class FlightManager : IFlightManager
    {
        /// <summary>
        /// The IDataAccess used to retrieve information.
        /// </summary>
        private readonly IDataAccess _dataAccess;

        /// <summary>
        /// The IFlightPriceCalculator user to calculate prices.
        /// </summary>
        private readonly IFlightPriceCalculator _flightPriceCalculator;


        /// <summary>
        /// Create a new instance of the FlightManager class using the given
        /// IDataAccess and IFlightPriceCalculator.
        /// </summary>
        /// <param name="dataAccess">The IDataAccess for this class to use.</param>
        /// <param name="flightPriceCalculator">The IFlightPriceCalculator for this class to use.</param>
        public FlightManager(IDataAccess dataAccess, IFlightPriceCalculator flightPriceCalculator)
        {
            _dataAccess = dataAccess;
            _flightPriceCalculator = flightPriceCalculator;
        }


        /// <summary>
        /// Find out whether there exists a flight that matches the given parameters.
        /// </summary>
        /// <param name="fromAirport">The origin airport of the flight.</param>
        /// <param name="toAirport">The destination airport of the flight.</param>
        /// <param name="onDate">The date of the flight.</param>
        /// <returns>An asynchronous task for finding whether a flight exists or not.</returns>
        public async Task<bool> ExistsFlightAsync(Airport fromAirport, Airport toAirport, DateTime onDate)
        {
            ICollection<Flight> flights = await _dataAccess.FindFlightsAsync(fromAirport, toAirport, onDate);

            if (flights.Count == 0)
            {
                // No flights.
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Find the cheapest inbound flight that matches the given parameters.
        /// </summary>
        /// <param name="filterParameters">The SearchFilterParameters to filter the flights by.</param>
        /// <returns>An asynchronous task for finding the flight.</returns>
        public async Task<Flight> FindCheapestInboundFlightAsync(SearchFilterParameters filterParameters)
        {
            List<Flight> flights = (await FindInboundFlightsAsync(filterParameters)).ToList();

            return await FindCheapestFlightAsync(flights);
        }

        /// <summary>
        /// Find the cheapest outbound flight that matches the given parameters.
        /// </summary>
        /// <param name="filterParameters">The SearchFilterParameters to filter the flights by.</param>
        /// <returns>An asynchronous task for finding the flight.</returns>
        public virtual async Task<Flight> FindCheapestOutboundFlightAsync(SearchFilterParameters filterParameters)
        {
            List<Flight> flights = (await FindOutboundFlightsAsync(filterParameters)).ToList();

            return await FindCheapestFlightAsync(flights);
        }

        private async Task<Flight> FindCheapestFlightAsync(List<Flight> flights)
        {
            if (flights.Count == 0)
            {
                // If there are no flights that match, return null.
                return null;
            }

            // Initialise the cheapest flight to the first one and calculate its price.
            Flight cheapestFlight = flights.First();
            decimal cheapestPrice = await _flightPriceCalculator.CalculateBasePriceAsync(cheapestFlight);

            // Loop through the rest of the flights.
            foreach (var flight in flights.Skip(1))
            {
                // Calculate the price of the current flight.
                decimal price = await _flightPriceCalculator.CalculateBasePriceAsync(flight);

                if (price < cheapestPrice)
                {
                    // If price of flight is cheaper than current cheapest flight, update
                    // cheaest flight and cheapest price.
                    cheapestFlight = flight;
                    cheapestPrice = price;
                }
            }

            return cheapestFlight;
        }

        /// <summary>
        /// Find the cost of the cheapest flights that match the parameters on days
        /// surrounding the date given in the search parameters.
        /// </summary>
        /// <param name="filterParameters">The parameters to filter the flight by.</param>
        /// <param name="searchPeriod">
        /// The number of days forward and backward
        /// in time that should be searched from the given date.
        /// </param>
        /// <returns>An asynchronous task for retrieving a dictionary of dates and prices.</returns>
        public async Task<Dictionary<DateTime, decimal>> FindCheapestPricesOnSimilarDatesAsync(SearchFilterParameters filterParameters, int searchPeriod)
        {
            DateTime middleDate = filterParameters.OutDate;
            Dictionary<DateTime, decimal> output = new Dictionary<DateTime, decimal>();

            for (int i = -searchPeriod; i <= searchPeriod; i++)
            {
                DateTime date = middleDate.AddDays(i);

                filterParameters.OutDate = date;

                Flight cheapestFlight = await FindCheapestOutboundFlightAsync(filterParameters);

                if ((cheapestFlight is null) || (cheapestFlight.DepartureDateTime < DateTime.Now))
                {
                    // No flight on given date or flight departure time is in the past.
                    output.Add(date, -1);
                    continue;
                }

                decimal price = await _flightPriceCalculator.CalculateBasePriceAsync(cheapestFlight);

                output.Add(date, price);
            }

            // Set out date back to original value.
            filterParameters.OutDate = middleDate;

            return output;
        }

        /// <summary>
        /// Find the inbound flights that match the given filter parameters.
        /// </summary>
        /// <param name="filterParameters">The parameters to filter the flight by.</param>
        /// <returns>An asynchronous task for finding the flights.</returns>
        public virtual async Task<List<Flight>> FindInboundFlightsAsync(SearchFilterParameters filterParameters)
        {
            if (filterParameters.Return == false)
            {
                // Flight is not a return flight.
                throw new InvalidOperationException("Flight is not a return flight");
            }

            Airport origin = filterParameters.OriginAirport;
            Airport destination = filterParameters.DestinationAirport;
            DateTime date = filterParameters.InDate;

            // Get flights from database going from destination -> origin on date.
            List<Flight> flights = await _dataAccess.FindFlightsAsync(destination, origin, date);

            return flights;
        }

        /// <summary>
        /// Find the outbound flights that match the given filter parameters.
        /// </summary>
        /// <param name="filterParameters">The parameters to filter the flight by.</param>
        /// <returns>An asynchronous task for finding the flights.</returns>
        public virtual async Task<List<Flight>> FindOutboundFlightsAsync(SearchFilterParameters filterParameters)
        {
            Airport origin = filterParameters.OriginAirport;
            Airport destination = filterParameters.DestinationAirport;
            DateTime date = filterParameters.OutDate;

            // Get flights from database going from origin -> destination on date.
            List<Flight> flights = await _dataAccess.FindFlightsAsync(origin, destination, date);

            return flights;
        }
    }
}
