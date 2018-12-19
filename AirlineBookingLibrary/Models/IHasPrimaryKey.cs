namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Defines a unique Id of type TKey.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key</typeparam>
    public interface IHasPrimaryKey<TKey>
    {
        TKey Id { get; }
    }
}
