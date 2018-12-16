using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingLibrary.Helpers
{
    public static class StringExtensions
    {
        public static string NullIfEmpty(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            else
            {
                return s;
            }
        }
    }
}
