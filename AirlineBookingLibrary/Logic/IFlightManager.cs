using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Logic
{
    /// <summary>
    /// Defines methods for retrieving flight information.
    /// </summary>
    public interface IFlightManager
    {
        /// <summary>
        /// Find outbound flights that match the given search parameters, asynchronously.
        /// </summary>
        /// <param name="filterParameters">The paramaters to filter the search by.</param>
        /// <returns>The asynchronous task for finding an ICollection of flights.</returns>
        Task<ICollection<Flight>> FindOutboundFlightsAsync(SearchFilterParameters filterParameters);

        /// <summary>
        /// Find inbound flights that match the given search parameters, asynchronously.
        /// </summary>
        /// <param name="filterParameters">The paramaters to filter the search by.</param>
        /// <returns>The asynchronous task for finding an ICollection of flights.</returns>
        Task<ICollection<Flight>> FindInboundFlightsAsync(SearchFilterParameters filterParameters);

        /// <summary>
        /// Find the cheapest outbound flight that matches the given search parameters, asynchronously.
        /// </summary>
        /// <param name="filterParameters">The paramaters to filter the search by.</param>
        /// <returns>The asynchronous task for finding the flight.</returns>
        Task<Flight> FindCheapestOutboundFlightAsync(SearchFilterParameters filterParameters);

        /// <summary>
        /// Find the cheapest inbound flight that matches the given search parameters, asynchronously.
        /// </summary>
        /// <param name="filterParameters">The paramaters to filter the search by.</param>
        /// <returns>The asynchronous task for finding the flight.</returns>
        Task<Flight> FindCheapestInboundFlightAsync(SearchFilterParameters filterParameters);

        /// <summary>
        /// Whether there exists a flight between two airports on a certain date.
        /// </summary>
        /// <param name="fromAirport">The origin airport.</param>
        /// <param name="toAirport">The destination airport.</param>
        /// <param name="onDate">The date to search on.</param>
        /// <returns>The asynchronous task for finding whether the flight exists.</returns>
        Task<bool> ExistsFlightAsync(Airport fromAirport, Airport toAirport, DateTime onDate);

        /// <summary>
        /// Find the lowest roundtrip price matching the given search parameters
        /// on similar dates, asynchronously. Will search dates no more than
        /// searchPeriod days forwards and backwards in time.
        /// </summary>
        /// <param name="filterParameters">The paramaters to filter the search by.</param>
        /// <param name="daysToSearch">
        /// The number of days forwards and backwards in time to search.</param>
        /// <returns>The asynchronous task for finding a dictionary of dates and cheapest roundtrip prices
        /// that match the search parameters on similar dates.
        /// </returns>
        Task<IDictionary<DateTime, decimal>> FindCheapestPricesOnSimilarDatesAsync(SearchFilterParameters filterParameters, int searchPeriod);
    }
}
