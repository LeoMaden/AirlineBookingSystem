using AirlineBookingLibrary.Logic;
using AirlineBookingLibrary.Models;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Helpers
{
    /// <summary>
    /// Provides extension methods for manipulating SelectedFlights objects.
    /// </summary>
    public static class SelectedFlightsExtensions
    {
        /// <summary>
        /// Convert this SelectedFlights object to a SelectedFlightsModel.
        /// </summary>
        /// <param name="selectedFlights">The SelectedFlights to convert.</param>
        /// <param name="calculator">The IFlightPriceCalculator to use to calculate flight prices.</param>
        public static async Task<SelectedFlightsModel> ToSelectedFlightsModel(this SelectedFlights selectedFlights, IFlightPriceCalculator calculator)
        {
            // Populate model with number of passengers and travel class.
            FlightSearchDataModel searchData = new FlightSearchDataModel
            {
                NumberAdults = selectedFlights.NumberAdults,
                NumberChildren = selectedFlights.NumberChildren,
                TravelClass = selectedFlights.TravelClass
            };

            SelectedFlightsModel output = new SelectedFlightsModel
            {
                Outbound = await selectedFlights.Outbound.PriceFlightAsync(searchData, calculator),
                Inbound = selectedFlights.Inbound is null ? null : await selectedFlights.Inbound.PriceFlightAsync(searchData, calculator),
                NumberAdults = selectedFlights.NumberAdults,
                NumberChildren = selectedFlights.NumberChildren,
                TravelClass = selectedFlights.TravelClass
            };

            output.TotalPrice = output.Outbound.TotalPrice;

            if (output.IsReturn)
            {
                output.TotalPrice += output.Inbound.TotalPrice;
            }

            return output;
        }
    }
}