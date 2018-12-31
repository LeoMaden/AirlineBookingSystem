using AirlineBookingLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    public class SelectedFlights
    {
        public Flight Outbound { get; set; }
        public Flight Inbound { get; set; }
        public int NumAdults { get; set; }
        public int NumChildren { get; set; }
        public decimal TotalPrice { get; set; }
        public TravelClass TravelClass { get; set; }
        public bool IsReturn { get; }

    }
}
