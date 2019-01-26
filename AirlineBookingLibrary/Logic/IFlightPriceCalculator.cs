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
        /// Calculate the base price of a flight.
        /// </summary>
        /// <param name="flight">The flight to find the base price of.</param>
        /// <returns>An asynchronous task for calculating the price of the flight.</returns>
        Task<decimal> CalculateBasePriceAsync(Flight flight);

        /// <summary>
        /// Calculate the total price for the specified flights and passengers.
        /// </summary>
        /// <param name="flights">The SelectedFlights object containing flight and passenger information.</param>
        /// <returns>An asynchronous task for calculating the total price.</returns>
        Task<decimal> CalculateTotalPriceAsync(SelectedFlights flights);
    }
}
