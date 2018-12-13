using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    public class BasketItem
    {
        public Flight OutFlight { get; set; }

        public Flight InFlight { get; set; }

        public bool Return { get; set; }

        public int NumberAdults { get; set; }

        public int NumberChildren { get; set; }

    }
}
