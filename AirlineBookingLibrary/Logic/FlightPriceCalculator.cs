using System;
using System.Threading.Tasks;
using AirlineBookingLibrary.Models;

namespace AirlineBookingLibrary.Logic
{
    /// <summary>
    /// An implementation of the IFlightPriceCalculator.
    /// </summary>
    public class FlightPriceCalculator : IFlightPriceCalculator
    {
        /// <summary>
        /// Calculate the price of a flight for a given number of people.
        /// </summary>
        /// <param name="flight">The flight to find the price of.</param>
        /// <param name="numAdults">The number of adults.</param>
        /// <param name="numChildren">The number of children.</param>
        /// <returns>An asynchronous task for calculating the price of the flight.</returns>
        public async Task<decimal> CalculatePriceAsync(Flight flight, int numAdults, int numChildren)
        {
            throw new NotImplementedException();
        }
    }
}
