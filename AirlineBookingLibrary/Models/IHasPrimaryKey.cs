namespace AirlineBookingLibrary.Models
{
    public interface IHasPrimaryKey<TKey>
    {
        TKey Id { get; }
    }
}
