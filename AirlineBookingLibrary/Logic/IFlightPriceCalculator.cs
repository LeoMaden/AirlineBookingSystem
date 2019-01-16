using AirlineBookingLibrary.Models;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Logic
{
    /// <summary>
    /// Defines methods for calculating the price of flights.
    /// </summary>
    public interface IFlightPriceCalculator
    {
        /// <summary>
        /// Calculate the price of a flight for a given number of people.
        /// </summary>
        /// <param name="flight">The flight to find the price of.</param>
        /// <param name="numAdults">The number of adults.</param>
        /// <param name="numChildren">The number of children.</param>
        /// <returns>An asynchronous task for calculating the price of the flight.</returns>
        Task<decimal> CalculatePriceAsync(Flight flight, int numAdults, int numChildren);
    }
}
