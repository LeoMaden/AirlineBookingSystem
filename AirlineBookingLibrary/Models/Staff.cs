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
    public class Staff : IHasPrimaryKey<int>
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
    }
}
