using AirlineBookingLibrary.Logic;
using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebUI.Models;

namespace WebUI.Helpers
{
    public static class SelectedFlightsExtensions
    {
        public static async Task<SelectedFlightsModel> ToSelectedFlightsModel(this SelectedFlights selectedFlights, IFlightPriceCalculator calculator)
        {
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