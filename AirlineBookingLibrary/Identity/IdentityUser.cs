using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace AirlineBookingLibrary.Identity
{
    public class IdentityUser : IUser<int>
    {
        public int Id { get; private set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }


    }
}
