using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;
using AirlineBookingLibrary.Models;
using HtmlAgilityPack;

namespace AirlineBookingLibrary.Logic
{
    /// <summary>
    /// An implementation of the IFlightPriceCalculator.
    /// </summary>
    public class FlightPriceCalculator : IFlightPriceCalculator
    {
        /// <summary>
        /// Create a new instance of the FlightPriceCalculator class.
        /// </summary>
        public FlightPriceCalculator()
        {
        }


        /// <summary>
        /// Calculate the base price of a flight.
        /// </summary>
        /// <param name="flight">The flight to find the base price of.</param>
        /// <returns>An asynchronous task for calculating the price of the flight.</returns>
        public virtual async Task<decimal> CalculateBasePriceAsync(Flight flight)
        {
            decimal baseCostPerMile = 0.15M;
            decimal baseFlightCost = 50;
            decimal onDayBookingMultiplier = 3;
            decimal actualCost = 0;

            decimal distance = (decimal)await GetDistanceAsync(flight.OriginAirport, flight.DestinationAirport);
            int daysToFlight = (int)Math.Round((flight.DepartureDateTime - DateTime.Now).TotalDays);

            actualCost = baseFlightCost + (baseCostPerMile * distance);

            // Apply extra costs if flight is booked on day or less than week before.
            if (daysToFlight == 0)
            {
                actualCost *= onDayBookingMultiplier;
            }
            else if (daysToFlight <= 7)
            {
                actualCost *= 0.5M * onDayBookingMultiplier;
            }

            // Round up to the next £5.
            actualCost = Math.Ceiling(actualCost / 5) * 5;

            return actualCost;
        }

        /// <summary>
        /// Calculate the total price for the specified flights and passengers.
        /// </summary>
        /// <param name="flights">The SelectedFlights object containing flight and passenger information.</param>
        /// <returns>An asynchronous task for calculating the total price.</returns>
        public async Task<decimal> CalculateTotalPriceAsync(SelectedFlights flights)
        {
            decimal firstClassMultiplier = 5;
            decimal childMultiplier = 0.6M;

            decimal perPersonCost = 0;
            decimal actualCost = 0;

            decimal outboundBaseCost = await CalculateBasePriceAsync(flights.Outbound);
            // Inbound flight base cost is calculated if return flight or 0 is flight is one-way.
            decimal inboundBaseCost = flights.IsReturn ? await CalculateBasePriceAsync(flights.Inbound) : 0;

            perPersonCost = outboundBaseCost + inboundBaseCost;

            if (flights.TravelClass == Enums.TravelClass.First)
            {
                perPersonCost *= firstClassMultiplier;
            }

            actualCost = (flights.NumAdults * perPersonCost) + (flights.NumChildren * perPersonCost * childMultiplier);

            flights.TotalPrice = actualCost;

            return actualCost;
        }


        private async Task<double> GetDistanceAsync(Airport origin, Airport destination)
        {
            string url = $"http://www.gcmap.com/dist?P={ origin.AirportCode }-{ destination.AirportCode }";

            using (HttpResponseMessage response = await GlobalConfig.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new HttpRequestException("Request could not be made");
                }

                string rawHtml = await response.Content.ReadAsStringAsync();
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(rawHtml);

                // Parse the response HTML to find the distance between airports.
                var distanceString = htmlDoc.DocumentNode.SelectSingleNode("//table[@id='mdist']//tbody//td[@class='d']").FirstChild.InnerText;

                double distance = double.Parse(distanceString.Replace(",", "").TrimEnd('m', 'i'));
                

                return distance;
            }
        }
    }
}
