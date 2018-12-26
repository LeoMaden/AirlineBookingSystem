using AirlineBookingLibrary;
using AirlineBookingLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        /// <summary>
        /// Private field to store the database context. 
        /// </summary>
        private IDataAccess _dataAccess;


        /// <summary>
        /// Create a new instance of the ManageController that
        /// retrieves user information from the IDataAccess provided.
        /// </summary>
        /// <param name="dataAccess">
        /// The IDataAccess that is used to get information about the current user
        /// </param>
        public ManageController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        //
        // GET /Manage
        async public Task<ActionResult> Index()
        {
            // Get authenticated user's username.
            var userName = User.Identity.Name;

            // Find authorised user details in database.
            var user = (await _dataAccess.FindByNameAsync(userName)).ToApplicationUser();

            return View(user);
        }
    }
}