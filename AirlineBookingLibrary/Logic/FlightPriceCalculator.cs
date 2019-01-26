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
        /// Calculate the base price of a flight.
        /// </summary>
        /// <param name="flight">The flight to find the base price of.</param>
        /// <returns>An asynchronous task for calculating the price of the flight.</returns>
        public async Task<decimal> CalculateBasePriceAsync(Flight flight)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculate the total price for the specified flights and passengers.
        /// </summary>
        /// <param name="flights">The SelectedFlights object containing flight and passenger information.</param>
        /// <returns>An asynchronous task for calculating the total price.</returns>
        public async Task<decimal> CalculateTotalPriceAsync(SelectedFlights flights)
        {
            return 123;
            throw new NotImplementedException();
        }
    }
}
