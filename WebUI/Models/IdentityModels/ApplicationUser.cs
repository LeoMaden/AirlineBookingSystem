using AirlineBookingLibrary.Models;
using Microsoft.AspNet.Identity;

namespace WebUI.Models.IdentityModels
{
    /// <summary>
    /// The User object for this application. Allows for 
    /// UI specific fields to be added to User class.
    /// </summary>
    public class ApplicationUser : User, IUser<int>
    {
    }
}