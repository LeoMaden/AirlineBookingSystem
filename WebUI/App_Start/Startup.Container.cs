using Autofac;
using Owin;
using WebUI.App_Start;

namespace WebUI
{
    public partial class Startup
    {
        public void ConfigureContainer(IAppBuilder app)
        {
            IContainer container = ContainerConfig.Configure();

            app.UseAutofacMiddleware(container);
        }
    }
}