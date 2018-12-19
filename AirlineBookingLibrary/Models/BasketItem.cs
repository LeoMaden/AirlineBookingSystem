namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a single basket item.
    /// </summary>
    public class BasketItem
    {
        public Flight OutFlight { get; set; }
        public Flight InFlight { get; set; }
        public bool Return { get; set; }
        public int NumberAdults { get; set; }
        public int NumberChildren { get; set; }
        public decimal Price { get; set; }

    }
}
