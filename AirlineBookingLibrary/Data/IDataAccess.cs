using AirlineBookingLibrary.Models;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Data
{
    public interface IDataAccess
    {
        //
        // User data access.
        Task CreateAsync(User user);
        Task CreateAddressAsync(User user);

        Task DeleteAsync(User user);
        Task DeleteAddressAsync(User user);

        Task<User> FindByEmailAsync(string email);

        Task<User> FindByIdAsync(int userId);
        Task<Address> FindAddressByIdAsync(int userId);

        Task<User> FindByNameAsync(string userName);

        Task UpdateAsync(User user);
        Task UpdateAddressAsync(User user);
    }
}