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
            var searchFilterModel = new SearchFilterModel();

            searchFilterModel.Airports = await GetAirportSelectListAsync();

            return View(searchFilterModel);
        }

        // POST: Search
        [HttpPost]
        public async Task<ActionResult> Index(SearchFilterModel searchFilterModel)
        {
            // Check model is valid.
            if (!ModelState.IsValid)
            {
                // Repopulate drowdown list box.
                searchFilterModel.Airports = await GetAirportSelectListAsync();

                return View(searchFilterModel);
            }

            // Get Airport objects from database using their Ids.
            Airport originAirport = await _dataAccess.FindAirportByIdAsync(searchFilterModel.SelectedOriginAirportId);
            Airport destinationAirport = await _dataAccess.FindAirportByIdAsync(searchFilterModel.SelectedDestinationAirportId);


            // Set inbound date to the value in the model if return flight,
            // otherwise the inbound date is a default DateTime().
            DateTime inboundDate = new DateTime();

            if (searchFilterModel.ReturnFlight == true)
            {
                inboundDate = searchFilterModel.InboundDate.Value;
            }


            // Map SearchFilterModel to SearchFilterParameters.
            SearchFilterParameters searchFilterParameters = new SearchFilterParameters
            {
                OriginAirport = originAirport,
                DestinationAirport = destinationAirport,
                OutDate = searchFilterModel.OutboundDate,
                InDate = inboundDate
            };

            var cheapestPricesOnSimilarDays = await _flightManager.FindCheapestPricesOnSimilarDatesAsync(searchFilterParameters, 2);



            return View(searchFilterModel);
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