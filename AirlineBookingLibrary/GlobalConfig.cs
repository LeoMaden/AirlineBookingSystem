using AirlineBookingLibrary.Data;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

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

        private static HttpClient _apiClient = null;


        /// <summary>
        /// Get a HttpClient for use in API calls throughtout the application.
        /// </summary>
        public static HttpClient ApiClient
        {
            get
            {
                if (_apiClient is null)
                {
                    throw new HttpRequestException("API Client has not been configured.");
                }

                return _apiClient;
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

        public static void ConfigureApiClient()
        {
            _apiClient = new HttpClient();

            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        
    }
}
