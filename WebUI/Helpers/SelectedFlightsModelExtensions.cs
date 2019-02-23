using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebUI.Models;

namespace WebUI.Helpers
{
    public static class SelectedFlightsModelExtensions
    {
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