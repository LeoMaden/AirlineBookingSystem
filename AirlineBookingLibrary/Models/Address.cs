using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    public class Address
    {
        /// <summary>
        /// Street name and house number.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Locality in which the user lives.
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// City where the user lives.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Postcode where the user lives.
        /// </summary>
        public string Postcode { get; set; }
    }
}
