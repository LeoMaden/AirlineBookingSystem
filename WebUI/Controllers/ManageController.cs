using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Logic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Helpers;
using WebUI.Models;

namespace WebUI.Controllers
{
    /// <summary>
    /// The controller responsible for managing user accounts.
    /// </summary>
    [Authorize]
    public class ManageController : Controller
    {
        private IDataAccess _dataAccess;
        public IBookingManager _bookingManager;

        /// <summary>
        /// Create a new instance of the ManageController that
        /// retrieves user information from the IDataAccess provided.
        /// </summary>
        /// <param name="dataAccess">
        /// The IDataAccess that is used to get information about the current user
        /// </param>
        public ManageController(IDataAccess dataAccess, IBookingManager bookingManager)
        {
            _dataAccess = dataAccess;
            _bookingManager = bookingManager;
        }

        //
        // GET /Manage
        [HttpGet]
        public async Task<ActionResult> Index(string partialViewName = "ViewAccountPartial")
        {
            // Get authenticated user's username.
            var userName = User.Identity.Name;

            // Find authorised user details in database.
            var user = await _dataAccess.FindByNameAsync(userName);

            // Find bookings for authorised user.
            var bookings = await _bookingManager.FindBookingsByUserAsync(user);

            AccountDetailsModel model = new AccountDetailsModel
            {
                AccountDetails = user.ToApplicationUser(),
                Bookings = bookings,
                PartialViewName = partialViewName
            };

            return View(model);
        }
    }
}