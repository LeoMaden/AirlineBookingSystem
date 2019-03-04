using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Logic;
using AirlineBookingLibrary.Models;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Helpers;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IDataAccess _dataAccess;
        private readonly IFlightPriceCalculator _calculator;
        private readonly IBookingManager _bookingManager;

        public BookingController(IDataAccess dataAccess, IFlightPriceCalculator calculator, IBookingManager bookingManager)
        {
            _dataAccess = dataAccess;
            _calculator = calculator;
            _bookingManager = bookingManager;
        }

        //
        // POST /Booking/SelectedFlights
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SelectedFlights(string outboundRadioGroup, string inboundRadioGroup)
        {
            // Try to get FlightSearchDataModel from session data.
            var searchData = (FlightSearchDataModel)Session["searchData"];

            SelectedFlights selectedFlights;

            bool parseOK = TryParseFlightIds(outboundRadioGroup, inboundRadioGroup, out selectedFlights);

            // Flight ids could not be parsed or search data from session is null.
            if ((parseOK == false) || (searchData is null))
            {
                return RedirectToAction("Index", "Search");
            }

            // Map data to selected flights object.
            selectedFlights.NumberAdults = searchData.NumberAdults;
            selectedFlights.NumberChildren = searchData.NumberChildren;
            selectedFlights.TravelClass = searchData.TravelClass;
            
            await CalculatePriceAsync(selectedFlights);


            SelectedFlightsModel selectedFlightsModel = await selectedFlights.ToSelectedFlightsModel(_calculator);

            // Add SelectedFlightsModel object to session data.
            Session.Add("selectedFlightsModel", selectedFlightsModel);

            return View(selectedFlightsModel);
        }

        //
        // GET /Booking/Payment
        [HttpGet]
        [Authorize]
        public ActionResult Payment()
        {
            // Get SelectedFlightsModel stored in session data.
            var selectedFlights = (SelectedFlightsModel)Session["selectedFlightsModel"];

            if (selectedFlights is null)
            {
                return View("Index");
            }

            PaymentDataModel model = new PaymentDataModel { SelectedFlights = selectedFlights };

            return View(model);
        }

        //
        // POST /Booking/Payment
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Payment(PaymentDataModel paymentData)
        {
            // Populate paymentData model with SelectedFlightsModel data.
            var selectedFlightsModel = (SelectedFlightsModel)Session["selectedFlightsModel"];
            paymentData.SelectedFlights = selectedFlightsModel;

            if (!ModelState.IsValid)
            {
                return View(paymentData);
            }

            User user = await _dataAccess.FindByNameAsync(User.Identity.Name);
            SelectedFlights selectedFlights = paymentData.SelectedFlights.ToSelectedFlights();
            PaymentInfo paymentInfo = paymentData.ToPaymentInfo();

            // Make booking.
            MethodResult result = await _bookingManager.MakeBookingAsync(user, selectedFlights, paymentInfo);

            // If booking did not succeed.
            if (result.Succeeded == false)
            {
                // Add errors to model.
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }

                return View(paymentData);
            }

            // Booking was successful.
            // Add details to session data.
            Session.Add("bookingInformation", paymentData);

            return RedirectToAction("Confirmation");
        }

        //
        // GET /Booking/Confirmation
        [HttpGet]
        public ActionResult Confirmation()
        {
            var bookingInfo = (PaymentDataModel)Session["bookingInformation"];

            if (bookingInfo is null)
            {
                // Redirect to start of booking process.
                return RedirectToAction("Index", "Search");
            }

            return View(bookingInfo);
        }

        /// <summary>
        /// Calculate and set the price property of the SelectedFlights object
        /// using the IFlightPriceCalculator.
        /// </summary>
        /// <param name="selectedFlights">The SelectedFlights object to calculate the price of.</param>
        /// <returns>An asynchronous task for calculating the flights' price.</returns>
        private async Task CalculatePriceAsync(SelectedFlights selectedFlights)
        {
            decimal price = await _calculator.CalculateTotalPriceAsync(selectedFlights);

            selectedFlights.Price = price;
        }

        /// <summary>
        /// Try to parse inbound and outbound flights Ids given as strings
        /// populating a SelectedFlights object with those flights if successful.
        /// </summary>
        /// <param name="outboundId">The outbound flight Id.</param>
        /// <param name="inboundId">The inbound flight Id.</param>
        /// <param name="selectedFlights">A selected flights object containing the flights with the Ids given.</param>
        /// <returns>True if the Ids were parsed correctly, false otherwise.</returns>
        private bool TryParseFlightIds(string outboundId, string inboundId, out SelectedFlights selectedFlights)
        {
            selectedFlights = null;

            if (outboundId is null)
            {
                // No oubound flight Id.
                return false;
            }

            int selectedOutboundId = int.Parse(outboundId);
            int? selectedInboundId = null;

            if (inboundId != null)
            {
                // Return flight is selected.
                selectedInboundId = int.Parse(inboundId);
            }

            // Find flight with given outbound Id.
            Task<Flight> outboundTask = Task.Run(async () => await _dataAccess.FindFlightByIdAsync(selectedOutboundId));
            Flight outbound = outboundTask.Result;
            Flight inbound = null;

            if (selectedInboundId.HasValue)
            {
                // Find flight with inbound Id if flight is a return flight.
                Task<Flight> inboundTask = Task.Run(async () => await _dataAccess.FindFlightByIdAsync(selectedInboundId.Value));
                inbound = inboundTask.Result;
            }

            // Populate selected flights object.
            selectedFlights = new SelectedFlights
            {
                Outbound = outbound,
                Inbound = inbound
            };

            return true;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            Exception exception = filterContext.Exception;

            if (exception is SmtpException mailException)
            {
                filterContext.Result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
                ViewBag.ErrorMessage = mailException.Message;
            }
            else
            {
                throw exception;
            }
        }
    }
}