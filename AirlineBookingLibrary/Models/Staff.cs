namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a member of staff.
    /// </summary>
    public class Staff : IHasPrimaryKey<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
