using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebUI.Models;

namespace WebUI.Helpers
{
    public static class FlightSearchDataModelExtensions
    {
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