using Autofac;
using Autofac.Integration.WebApi;
using InstaSport.Data;
using InstaSport.Data.Common;
using InstaSport.Services.Data;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;

namespace InstaSport.WebApi.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(x => new InstaSportDbContext())
               .As<DbContext>()
               .InstancePerRequest();

            var servicesAssembly = Assembly.GetAssembly(typeof(ILocationsService));
            builder.RegisterAssemblyTypes(servicesAssembly).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(DbRepository<>))
                .As(typeof(IDbRepository<>))
                .InstancePerRequest();
        }
    }
}