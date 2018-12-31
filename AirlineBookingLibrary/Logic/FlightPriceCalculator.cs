using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingLibrary.Models;

namespace AirlineBookingLibrary.Logic
{
    public class FlightPriceCalculator : IFlightPriceCalculator
    {
        public async Task<decimal> CalculatePriceAsync(Flight flight, int numAdults, int numChildren)
        {
            throw new NotImplementedException();
        }
    }
}
