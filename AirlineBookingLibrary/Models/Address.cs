namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a user's address.
    /// </summary>
    public class Address
    {
        public string StreetAddress { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
    }
}
