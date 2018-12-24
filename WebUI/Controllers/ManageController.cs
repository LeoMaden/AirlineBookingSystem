using AirlineBookingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class ManageController : Controller
    {
        //
        // GET /Manage
        async public Task<ActionResult> Index()
        {
            var userName = User.Identity.Name;

            var user = (await GlobalConfig.DbContext.FindByNameAsync(userName)).ToApplicationUser();

            return View(user);
        }
    }
}