using AirlineBookingLibrary.Models;
using Microsoft.AspNet.Identity;

namespace WebUI.Models.IdentityModels
{
    public class ApplicationUser : User, IUser<int>
    {
    }
}