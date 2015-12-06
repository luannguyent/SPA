using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using BookingSystem.DataAccess.UserManager;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BookingSystem.WebAPI.Startup))]

namespace BookingSystem.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //var builder = new ContainerBuilder();
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<UserManager>().As<IUserManager>().InstancePerLifetimeScope();
            //IContainer container = builder.Build();
            //GlobalConfiguration.Configuration.DependencyResolver =
            //        new AutofacWebApiDependencyResolver(container);
            //var builder = new ContainerBuilder();
            //var config = new HttpConfiguration();
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<UserManager>().As<IUserManager>().InstancePerLifetimeScope();
            //var container = builder.Build();
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //GlobalConfiguration.Configuration.DependencyResolver = config.DependencyResolver;
            //app.UseAutofacMiddleware(container);
            //app.UseAutofacWebApi(config);
            //app.UseWebApi(config);
            DependencyConfig.RegisterDependencyResolvers();
        }
    }
}
