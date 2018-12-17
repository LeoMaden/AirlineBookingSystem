using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Models
{
    /// <summary>
    /// Represents a member of staff.
    /// </summary>
    public class Staff : IUser<int>
    {
        /// <summary>
        /// Unique ID for this staff member.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Unique username for this staff member.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Hash of this staff member's password.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Salt used to create this staff member's password hash.
        /// </summary>
        public string PasswordSalt { get; set; }
    }
}
