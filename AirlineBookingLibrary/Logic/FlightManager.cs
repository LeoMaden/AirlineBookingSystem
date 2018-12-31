using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineBookingLibrary.Models;

namespace AirlineBookingLibrary.Logic
{
    public class FlightManager : IFlightManager
    {
        public async Task<bool> ExistsFlightAsync(Airport fromAirport, Airport toAirport, DateTime onDate)
        {
            throw new NotImplementedException();
        }

        public async Task<Flight> FindCheapestInboundFlightAsync(SearchFilterParameters filterParameters)
        {
            throw new NotImplementedException();
        }

        public async Task<Flight> FindCheapestOutboundFlightAsync(SearchFilterParameters filterParameters)
        {
            throw new NotImplementedException();
        }

        public async Task<IDictionary<DateTime, decimal>> FindCheapestPricesOnSimilarDatesAsync(SearchFilterParameters filterParameters, int searchPeriod)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Flight>> FindInboundFlightsAsync(SearchFilterParameters filterParameters)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Flight>> FindOutboundFlightsAsync(SearchFilterParameters filterParameters)
        {
            throw new NotImplementedException();
        }
    }
}
