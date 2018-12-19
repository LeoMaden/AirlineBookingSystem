using AirlineBookingLibrary.Models;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Data
{
    public interface IDataAccess
    {
        //
        // User data access.
        Task CreateAsync(User user);
        Task DeleteAsync(User user);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByIdAsync(int userId);
        Task<User> FindByNameAsync(string userName);
        Task<string> GetEmailAsync(User user);
        Task<string> GetPasswordHashAsync(User user);
        Task<string> GetPhoneNumberAsync(User user);
        Task<bool> HasPasswordAsync(User user);
        Task SetEmailAsync(User user, string email);
        Task SetPasswordHashAsync(User user, string passwordHash);
        Task SetPhoneNumberAsync(User user, string phoneNumber);
        Task UpdateAsync(User user);
    }
}