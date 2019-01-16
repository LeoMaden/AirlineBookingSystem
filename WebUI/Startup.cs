using Microsoft.Owin;
using Owin;
using WebUI.App_Start;

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
        }
    }
}
