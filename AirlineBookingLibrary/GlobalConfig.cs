using AirlineBookingLibrary.Data;
using System.Configuration;

namespace AirlineBookingLibrary
{
    /// <summary>
    /// A static class that provides global access to certain data.
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// Get the DefaultConnection connection string from the .config
        /// file where this library is being run from.
        /// E.g. App.Config or Web.config file.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }
    }
}
