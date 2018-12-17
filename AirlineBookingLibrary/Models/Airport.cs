using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    public class Airport : IHasPrimaryKey<int>
    {
        public int Id { get; set; }

        public string AirportCode { get; set; }

        public string FriendlyName { get; set; }


    }
}
