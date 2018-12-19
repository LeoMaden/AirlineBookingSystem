using AirlineBookingLibrary.Data;
using System.Configuration;

namespace AirlineBookingLibrary
{
    public static class GlobalConfig
    {
        public static IDataAccess DbContext { get; private set; }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }


        static GlobalConfig()
        {
            InitialiseConnection();
        }

        private static void InitialiseConnection()
        {
            DbContext = new SQLDataAccess() as IDataAccess;
        }
    }
}
