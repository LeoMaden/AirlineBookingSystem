using AirlineBookingLibrary.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.IdentityModels
{
    public class ApplicationUser : User, IUser<int>
    {
    }
}