using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PricedFlight
    {
        public FlightSearchDataModel SearchData { get; set; }

        public Flight Flight { get; set; }

        public decimal TotalPrice { get; set; }
    }
}