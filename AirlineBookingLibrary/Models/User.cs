using System;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a user of the system.
    /// </summary>
    public class User : IHasPrimaryKey<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
