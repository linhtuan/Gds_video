using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Gds.BusinessObject.DbContext;
using Gds.Frontend.Domain;
using Gds.Frontend.Infrastructure;
using MvcCornerstone.Data;
using MvcCornerstone.Data.Entity;
using MvcCornerstone.Factory;

namespace Gds.Video.Infrastructure
{
    public class AutofacInstaller
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(BaseController).Assembly);
            builder.RegisterType<DaoFactory>().As<IDaoFactory>().InstancePerRequest();

            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IEntityRepository<>)).InstancePerDependency();
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>().InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(ICategoryService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerHttpRequest();

            builder.RegisterFilterProvider();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            var container = builder.Build();

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }
}