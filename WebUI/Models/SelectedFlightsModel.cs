using AirlineBookingLibrary.Enums;

namespace WebUI.Models
{
    public class SelectedFlightsModel
    {
        public PricedFlight Outbound { get; set; }

        public PricedFlight Inbound { get; set; }

        public int NumberAdults { get; set; }

        public int NumberChildren { get; set; }

        public decimal TotalPrice { get; set; }

        public TravelClass TravelClass { get; set; }

        public bool IsReturn
        {
            get
            {
                return Inbound != null;
            }
        }
    }
}