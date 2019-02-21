using AirlineBookingLibrary.Enums;
using AirlineBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class FlightSearchDataModel
    {
        public SelectList Airports { get; set; }

        [Required]
        public int? SelectedOriginAirportId { get; set; } = null;

        [Required]
        public int? SelectedDestinationAirportId { get; set; } = null;


        [Required(ErrorMessage = "Please select a departure date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OutboundDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Please select one way/return flight")]
        public bool ReturnFlight { get; set; } = false;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? InboundDate { get; set; } = DateTime.Today.AddDays(7);

        [Range(1, 8, ErrorMessage = "Number of adults must be between 1 and 8")]
        public int NumberAdults { get; set; } = 1;

        [Range(0, 8, ErrorMessage = "Number of adults must be between 0 and 8")]
        public int NumberChildren { get; set; } = 0;

        [EnumDataType(typeof(TravelClass))]
        public TravelClass TravelClass { get; set; } = TravelClass.Economy;

        // -----------------------------------------------------------

        public Dictionary<DateTime, decimal> CheapestPricesOnSimilarDates { get; set; }

        public List<Flight> OutboundFlights { get; set; }

        public List<Flight> InboundFlights { get; set; }



    }
}