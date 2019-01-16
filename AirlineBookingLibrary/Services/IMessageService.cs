using System.Threading.Tasks;

namespace AirlineBookingLibrary.Services
{
    public interface IMessageService
    {
        Task SendAsync(string destination, string subject, string body);
    }
}