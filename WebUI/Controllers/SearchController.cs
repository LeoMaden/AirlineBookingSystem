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
        private readonly IFlightPriceCalculator _priceCalculator;

        public SearchController(IDataAccess dataAccess, IFlightManager flightManager, IFlightPriceCalculator priceCalculator)
        {
            _dataAccess = dataAccess;
            _flightManager = flightManager;
            _priceCalculator = priceCalculator;
        }

        //
        // GET /Search
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

        // POST /Search
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

            // Add search data to session so it can be used later.
            Session.Add("searchData", flightSearchDataModel);

            await FillModel(flightSearchDataModel);

            return View(flightSearchDataModel);
        }

        //
        // GET /Search/ChangeDate?ticks=1234
        [HttpGet]
        public async Task<ActionResult> ChangeDate(string ticks)
        {
            // Parse ticks string into new datetime object.
            DateTime newOutDate = new DateTime(long.Parse(ticks));

            FlightSearchDataModel searchData = (FlightSearchDataModel)Session["searchData"];

            if (searchData is null)
            {
                return View("Index");
            }

            // Calculate difference between dates.
            TimeSpan dateDifference = newOutDate - searchData.OutboundDate;

            // Add difference to inbound and outbound dates.
            searchData.OutboundDate += dateDifference;

            if (searchData.ReturnFlight == true)
            {
                searchData.InboundDate += dateDifference;
            }

            await FillModel(searchData);

            return View("Index", searchData);
        }

        // 
        // GET /Search/FeaturedDestinations?featuredDestination=paris
        [HttpGet]
        public async Task<ActionResult> FeaturedDestinations(string featuredDestination)
        {
            var flightSearchDataModel = new FlightSearchDataModel();

            // Set airports list in search filter model.
            flightSearchDataModel.Airports = await GetAirportSelectListAsync();

            // Get List<Airport>
            var airports = await _dataAccess.GetAirportsAsync();

            // Get the origin airport (LHR).
            Airport origin = airports.Where(x => x.AirportCode == "LHR").First();
            Airport destination = null;

            switch (featuredDestination)
            {
                case "paris":
                    destination = airports.Where(x => x.AirportCode == "CDG").First();
                    break;
                case "new york":
                    destination = airports.Where(x => x.AirportCode == "JFK").First();
                    break;
                case "amsterdam":
                    destination = airports.Where(x => x.AirportCode == "AMS").First();
                    break;
                default:
                    return View("Index");
            }

            // Set origin and destination ids.
            flightSearchDataModel.SelectedOriginAirportId = origin.Id;
            flightSearchDataModel.SelectedDestinationAirportId = destination.Id;
            flightSearchDataModel.ReturnFlight = true;

            // Depart a week from now and return the week after that by default.
            flightSearchDataModel.OutboundDate = DateTime.Today.AddDays(7);
            flightSearchDataModel.InboundDate = DateTime.Today.AddDays(14);

            // Fill model with flights.
            await FillModel(flightSearchDataModel);

            // Add search data to session so it can be used later.
            Session.Add("searchData", flightSearchDataModel);

            return View("Index", flightSearchDataModel);
        }

        private SelectList ToSelectList(List<Airport> airports)
        {
            SelectList output = new SelectList(airports, nameof(Airport.Id), nameof(Airport.FriendlyName));

            return output;
        }

        private async Task<SelectList> GetAirportSelectListAsync()
        {
            List<Airport> airports = await _dataAccess.GetAirportsAsync();

            return ToSelectList(airports);
        }

        /// <summary>
        /// Populate a FlightSearchDataModel with airports, etc. from the database.
        /// </summary>
        /// <param name="flightSearchDataModel">The object to populate.</param>
        private async Task FillModel(FlightSearchDataModel flightSearchDataModel)
        {
            // Clear out existing items in lists.
            flightSearchDataModel.CheapestPricesOnSimilarDates = new Dictionary<DateTime, decimal>();
            flightSearchDataModel.OutboundFlights = new List<PricedFlight>();
            flightSearchDataModel.InboundFlights = new List<PricedFlight>();

            var searchFilterParameters = await flightSearchDataModel.ToSearchFilterParameters(_dataAccess);

            // Set cheapest prices on similar dates.
            flightSearchDataModel.CheapestPricesOnSimilarDates = await _flightManager.FindCheapestPricesOnSimilarDatesAsync(searchFilterParameters, 2);

            // Set outbound flight list.
            List<Flight> outboundFlights = await _flightManager.FindOutboundFlightsAsync(searchFilterParameters);

            foreach (var flight in outboundFlights)
            {
                // Loop through and price each flight then add it to model list.
                flightSearchDataModel.OutboundFlights.Add(await flight.PriceFlightAsync(flightSearchDataModel, _priceCalculator));
            }

            // Set inbound flight list.
            if (flightSearchDataModel.ReturnFlight == true)
            {
                // Flight is return flight.
                List<Flight> inboundFlights = await _flightManager.FindInboundFlightsAsync(searchFilterParameters);

                foreach (var flight in inboundFlights)
                {
                    // Loop through and price each flight then add it to model list.
                    flightSearchDataModel.InboundFlights.Add(await flight.PriceFlightAsync(flightSearchDataModel, _priceCalculator));
                }
            }
            else
            {
                // Not a return flight.
                flightSearchDataModel.InboundFlights = null;
            }
        }
    }
}