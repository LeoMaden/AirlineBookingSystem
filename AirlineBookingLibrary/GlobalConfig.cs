using AirlineBookingLibrary.Data;
using System;
using System.Configuration;
using System.Diagnostics;

namespace AirlineBookingLibrary
{
    /// <summary>
    /// A static class that provides global access to certain data.
    /// </summary>
    public static class GlobalConfig
    {
        // Names of connection strings for debug and release databases.
        private const string _debugConnectionStringName = "DebugConnection";
        private const string _releaseConnectionStringName = "ReleaseConnection";

        // The name of the connection string this application is using.
        private static string _currentConnectionStringName = null;


        public static void ConfigureConnectionString()
        {
            if (Debugger.IsAttached)
            {
                // Use debug database if debugger is attached.
                _currentConnectionStringName = _debugConnectionStringName;
            }
            else
            {
                _currentConnectionStringName = _releaseConnectionStringName;
            }
        }

        /// <summary>
        /// Get the connection string being used by this instance
        /// of the application.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (_currentConnectionStringName is null)
                {
                    // Throw exception if connection string has not been initialised.
                    throw new InvalidOperationException("Connection string has not been configured");
                }

                // Get connection string from config file.
                return ConfigurationManager.ConnectionStrings[_currentConnectionStringName].ConnectionString;
            }
        }
    }
}
