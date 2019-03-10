using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Models;
using System;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Helpers
{
    /// <summary>
    /// Provides extension methods for manipulating FlightSearchDataModel objects.
    /// </summary>
    public static class FlightSearchDataModelExtensions
    {
        /// <summary>
        /// Convert a FlightSearchDataModel to a SearchFilterParameters object.
        /// </summary>
        /// <param name="flightSearchDataModel">The FlightSearchDataModel to convert.</param>
        /// <param name="dataAccess">The IDataAccess to use to obtain Airports from Ids.</param>
        /// <returns>An asynchronous task for finding converting the FlightSearchDataModel.</returns>
        public static async Task<SearchFilterParameters> ToSearchFilterParameters(this FlightSearchDataModel flightSearchDataModel, IDataAccess dataAccess)
        {
            // Get Airport objects from database using their Ids.
            Airport originAirport = await dataAccess.FindAirportByIdAsync(flightSearchDataModel.SelectedOriginAirportId.Value);
            Airport destinationAirport = await dataAccess.FindAirportByIdAsync(flightSearchDataModel.SelectedDestinationAirportId.Value);

            // Set inbound date to the value in the model if return flight,
            // otherwise the inbound date is a default DateTime().
            DateTime inboundDate = new DateTime();

            if (flightSearchDataModel.ReturnFlight == true)
            {
                inboundDate = flightSearchDataModel.InboundDate.Value;
            }

            // Map SearchFilterModel to SearchFilterParameters.
            SearchFilterParameters output = new SearchFilterParameters
            {
                OriginAirport = originAirport,
                DestinationAirport = destinationAirport,
                OutDate = flightSearchDataModel.OutboundDate,
                InDate = inboundDate
            };

            return output;
        }
    }
}