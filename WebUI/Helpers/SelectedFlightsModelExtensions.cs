using AirlineBookingLibrary.Models;
using WebUI.Models;

namespace WebUI.Helpers
{
    /// <summary>
    /// Provides extension methods for manipulating SelectedFlightsModel objects.
    /// </summary>
    public static class SelectedFlightsModelExtensions
    {
        /// <summary>
        /// Convert this SelectedFlightsModel to a SelectedFlights object.
        /// </summary>
        /// <param name="model">The SelectedFlightsModel to convert.</param>
        public static SelectedFlights ToSelectedFlights(this SelectedFlightsModel model)
        {
            var output = new SelectedFlights
            {
                Outbound = model.Outbound.Flight,
                NumberAdults = model.NumberAdults,
                NumberChildren = model.NumberChildren,
                TravelClass = model.TravelClass,
                Price = model.TotalPrice
            };

            if (model.IsReturn)
            {
                output.Inbound = model.Inbound.Flight;
            }

            return output;
        }
    }
}