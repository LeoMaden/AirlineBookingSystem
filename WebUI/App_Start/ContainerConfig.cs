using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebUI.Models.IdentityModels;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using WebUI.Controllers;
using AirlineBookingLibrary.Data;
using AirlineBookingLibrary.Logic;
using AirlineBookingLibrary.Services;

namespace WebUI.App_Start
{
    /// <summary>
    /// Configure the AutoFac container for this application.
    /// </summary>
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            // Create container builder.
            var builder = new ContainerBuilder();

            // Register MVC Controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register controllers and their dependencies.
            builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<AccountController>().InstancePerRequest();
            builder.RegisterType<ManageController>().InstancePerRequest();

            // Register WebUI types.
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser, int>>();
            builder.RegisterType<ApplicationUserManager>().As<UserManager<ApplicationUser, int>>();
            builder.RegisterType<ApplicationSignInManager>().As<SignInManager<ApplicationUser, int>>();

            // Register AirlineBookingLibrary types.
            builder.RegisterType<SQLDataAccess>().As<IDataAccess>();
            builder.RegisterType<BookingManager>().As<IBookingManager>();
            builder.RegisterType<FlightManager>().As<IFlightManager>();
            builder.RegisterType<FlightPriceCalculator>().As<IFlightPriceCalculator>();
            builder.RegisterType<PaymentManager>().As<IPaymentManager>();
            builder.RegisterType<EmailService>().As<IMessageService>();

            // Build container.
            IContainer container = builder.Build();

            // Set dependency resolver to be Autofac.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            return container;
        }
    }
}