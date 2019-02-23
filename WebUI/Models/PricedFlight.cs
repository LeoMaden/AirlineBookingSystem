using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PricedFlight
    {
        public Flight Flight { get; set; }

        public decimal TotalPrice { get; set; }
    }
}