using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IDataAccess _dataAccess;

        public HomeController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

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

        private async Task<SelectList> GetAirportSelectListAsync()
        {
            List<Airport> airports = (await _dataAccess.GetAirportsAsync()).ToList();

            return ToSelectList(airports);
        }

        private SelectList ToSelectList(List<Airport> airports)
        {
            SelectList output = new SelectList(airports, nameof(Airport.Id), nameof(Airport.FriendlyName));

            return output;
        }
    }
}