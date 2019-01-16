using AirlineBookingLibrary.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please enter your title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string HouseNumber { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string Postcode { get; set; }

        [Required]
        public Address SelectedAddress { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


    }
}