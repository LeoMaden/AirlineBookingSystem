namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents an airport.
    /// </summary>
    public class Airport : IHasPrimaryKey<int>
    {
        public int Id { get; set; }
        public string AirportCode { get; set; }
        public string FriendlyName { get; set; }
    }
}
