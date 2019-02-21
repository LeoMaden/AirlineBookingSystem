using AirlineBookingLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Helpers;
using AirlineBookingLibrary.Models;
using System.Threading.Tasks;
using AirlineBookingLibrary.Data;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class SearchController : Controller
    {
        private readonly IFlightManager _flightManager;
        private readonly IDataAccess _dataAccess;

        public SearchController(IDataAccess dataAccess, IFlightManager flightManager)
        {
            _dataAccess = dataAccess;
            _flightManager = flightManager;
        }

        // GET: Search
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var flightSearchDataModel = new FlightSearchDataModel();

            // Set airports list in search filter model.
            flightSearchDataModel.Airports = await GetAirportSelectListAsync();


            // GET request so no airports have been selected.
            // Set outbound and inbound flights to null.
            flightSearchDataModel.OutboundFlights = null;
            flightSearchDataModel.InboundFlights = null;

            return View(flightSearchDataModel);
        }

        // POST: Search
        [HttpPost]
        public async Task<ActionResult> Index(FlightSearchDataModel flightSearchDataModel)
        {
            // Repopulate drowdown list box.
            flightSearchDataModel.Airports = await GetAirportSelectListAsync();

            // Check if model is invalid.
            if (!ModelState.IsValid)
            {
                return View(flightSearchDataModel);
            }

            // Model is valid.

            var searchFilterParameters = await flightSearchDataModel.ToSearchFilterParameters(_dataAccess);

            // Set cheapest prices on similar dates.
            flightSearchDataModel.CheapestPricesOnSimilarDates = await _flightManager.FindCheapestPricesOnSimilarDatesAsync(searchFilterParameters, 2);

            // Set outbound flight list.
            flightSearchDataModel.OutboundFlights = await _flightManager.FindOutboundFlightsAsync(searchFilterParameters);

            // Set inbound flight list.
            if (flightSearchDataModel.ReturnFlight == true)
            {
                // Flight is return flight.
                flightSearchDataModel.InboundFlights = await _flightManager.FindInboundFlightsAsync(searchFilterParameters);
            }
            else
            {
                // Not a return flight.
                flightSearchDataModel.InboundFlights = null;
            }


            return View(flightSearchDataModel);
        }

        private SelectList ToSelectList(List<Airport> airports)
        {
            SelectList output = new SelectList(airports, nameof(Airport.Id), nameof(Airport.FriendlyName));

            return output;
        }

        private async Task<SelectList> GetAirportSelectListAsync()
        {
            List<Airport> airports = (await _dataAccess.GetAirportsAsync()).ToList();

            return ToSelectList(airports);
        }

        
    }
}