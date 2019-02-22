using AirlineBookingLibrary.Logic;
using AirlineBookingLibrary.Models;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Helpers
{
    public static class FlightExtensions
    {
        public static async Task<PricedFlight> PriceFlightAsync(this Flight flight, FlightSearchDataModel searchData, IFlightPriceCalculator calculator)
        {
            // Create PricedFlight object.
            var output = new PricedFlight
            {
                Flight = flight,
                SearchData = searchData
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