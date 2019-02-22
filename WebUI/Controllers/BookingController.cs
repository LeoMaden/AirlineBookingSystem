using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Logic;
using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IDataAccess _dataAccess;
        private readonly IFlightPriceCalculator _calculator;

        public BookingController(IDataAccess dataAccess, IFlightPriceCalculator calculator)
        {
            _dataAccess = dataAccess;
            _calculator = calculator;
        }

        // GET: Booking/SelectedFlights?selectedOutboundId=xx
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SelectedFlights(string outboundRadioGroup, string inboundRadioGroup)
        {
            // Try to get FlightSearchDataModel from session data.
            var searchData = (FlightSearchDataModel)Session["searchData"];

            if (searchData is null)
            {
                return RedirectToAction("Index", "Search");
            }

            SelectedFlights selectedFlights = await ParseFlightIds(outboundRadioGroup, inboundRadioGroup);

            // Map data to selected flights object.
            selectedFlights.NumberAdults = searchData.NumberAdults;
            selectedFlights.NumberChildren = searchData.NumberChildren;
            selectedFlights.TravelClass = searchData.TravelClass;
            
            await CalculatePriceAsync(selectedFlights);

            return View(selectedFlights);
        }

        private async Task CalculatePriceAsync(SelectedFlights selectedFlights)
        {
            decimal price = await _calculator.CalculateTotalPriceAsync(selectedFlights);

            selectedFlights.Price = price;
        }

        private async Task<SelectedFlights> ParseFlightIds(string outboundId, string inboundId)
        {
            int selectedOutboundId = int.Parse(outboundId);
            int? selectedInboundId = null;

            if (inboundId != null)
            {
                // Return flight is selected.
                selectedInboundId = int.Parse(inboundId);
            }

            Flight outbound = await _dataAccess.FindFlightByIdAsync(selectedOutboundId);
            Flight inbound = null;

            if (selectedInboundId.HasValue)
            {
                inbound = await _dataAccess.FindFlightByIdAsync(selectedInboundId.Value);
            }

            return new SelectedFlights { Outbound = outbound, Inbound = inbound };
        }
    }
}