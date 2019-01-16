using Autofac;
using Owin;
using WebUI.App_Start;

namespace WebUI
{
    public partial class Startup
    {
        /// <summary>
        /// Configure the application to use AutoFac.
        /// </summary>
        public void ConfigureContainer(IAppBuilder app)
        {
            IContainer container = ContainerConfig.Configure();

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}