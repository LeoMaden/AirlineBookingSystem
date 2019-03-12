using AirlineBookingLibrary.Models;
using System.Collections.Generic;
using WebUI.Models.IdentityModels;

namespace WebUI.Models
{
    public class AccountDetailsModel
    {
        public ApplicationUser AccountDetails { get; set; }

        public List<Booking> Bookings { get; set; }

        public string PartialViewName { get; set; }

    }
}