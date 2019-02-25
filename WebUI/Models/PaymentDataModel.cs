using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class PaymentDataModel
    {
        [Required]
        [Display(Name = "Name on card")]
        public string NameOnCard { get; set; }

        [Required]
        [Display(Name = "Card number")]
        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Exipry month")]
        [Range(1, 12, ErrorMessage = "Month must be between 1 and 12")]
        public int ExpiryMonth { get; set; }

        [Required]
        [Display(Name = "Expiry year")]
        public int ExipryYear { get; set; }

        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        [DataType(DataType.Password)]
        public string CVV { get; set; }



        public SelectedFlightsModel SelectedFlights { get; set; }

    }
}