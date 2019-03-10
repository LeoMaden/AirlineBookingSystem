using AirlineBookingLibrary.Logic;
using AirlineBookingLibrary.Models;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Helpers
{
    /// <summary>
    /// Provides extension methods for manipulating Flight objcts.
    /// </summary>
    public static class FlightExtensions
    {
        /// <summary>
        /// Convert a Flight object to a PricedFlight object.
        /// </summary>
        /// <param name="flight">The flight to convert and price.</param>
        /// <param name="searchData">The FlightSearchDataModel to be used to help calculate the price of the flight.</param>
        /// <param name="calculator">The IFlightPriceCalculator to be used to help calculate the price of the flight.</param>
        /// <returns>An asynchronous task for pricing the flight.</returns>
        public static async Task<PricedFlight> PriceFlightAsync(this Flight flight, FlightSearchDataModel searchData, IFlightPriceCalculator calculator)
        {
            // Create PricedFlight object.
            var output = new PricedFlight
            {
                Flight = flight
            };

            // Put contents of flight and search data into SelectedFlights object
            // so total price can be calculated.
            var totalFlight = new SelectedFlights
            {
                Outbound = flight,
                Inbound = null,
                NumberAdults = searchData.NumberAdults,
                NumberChildren = searchData.NumberChildren,
                TravelClass = searchData.TravelClass
            };

            decimal price = await calculator.CalculateTotalPriceAsync(totalFlight);

            output.TotalPrice = price;

            return output;
        }
    }
}