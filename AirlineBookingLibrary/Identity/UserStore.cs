using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Identity
{
    public class UserStore : UserStore<User, UserRole, int, UserLogin, UserRole, UserClaim>
    {
        public UserStore(ApplicationDbContext context)
           : base(context)
        {
        }
    }
}
