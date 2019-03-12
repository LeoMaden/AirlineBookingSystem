using AirlineBookingLibrary;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebUI.Startup))]
namespace WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure authentication for the app.
            ConfigureAuth(app);

            // Register app to use Autofac.
            ConfigureContainer(app);

            // Configure connection string for database.
            GlobalConfig.ConfigureConnectionString();

            // Configure an API client.
            GlobalConfig.ConfigureApiClient();
        }
    }
}
