using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a user of the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The unique ID for this user.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// The user's title (Mr, Mrs, Dr, etc.)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The user's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The user's unique username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The user's date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// First line of user's address.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Second line of user's address.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// City where the user lives.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Postcode where the user lives.
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// The user's contact email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The users contact number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Date this user created their account.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Hash of this user's password.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Salt used to create this user's password hash.
        /// </summary>
        public string PasswordSalt { get; set; }

    }
}
