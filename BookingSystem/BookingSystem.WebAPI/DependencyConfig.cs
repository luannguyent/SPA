using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using BookingSystem.DataAccess;
using BookingSystem.DataAccess.Contracts;
using BookingSystem.DataAccess.Implements;
using BookingSystem.DataAccess.UserManager;
using BookingSystem.Service.Contracts;
using BookingSystem.Service.Implements;

namespace BookingSystem.WebAPI
{
    public class DependencyConfig
    {
        public static IContainer RegisterDependencyResolvers()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UserManager>().As<IUserManager>().InstancePerLifetimeScope();
            builder.RegisterType<BookingSystemEntities>().As<IDataContext>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<TypeService>().As<ITypeService>().InstancePerLifetimeScope();
            builder.RegisterType<PropertyService>().As<IPropertyService>().InstancePerLifetimeScope();
            builder.RegisterType<ReservationService>().As<IReservationService>().InstancePerLifetimeScope();
            IContainer container = builder.Build();
            // Set Up WebAPI Resolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}