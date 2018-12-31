using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Logic
{
    public interface IFlightPriceCalculator
    {
        Task<decimal> CalculatePriceAsync(Flight flight, int numAdults, int numChildren);
    }
}
