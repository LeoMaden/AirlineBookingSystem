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
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
