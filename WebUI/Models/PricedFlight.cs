using AirlineBookingLibrary.Models;

namespace WebUI.Models
{
    public class PricedFlight
    {
        public Flight Flight { get; set; }

        public decimal TotalPrice { get; set; }
    }
}