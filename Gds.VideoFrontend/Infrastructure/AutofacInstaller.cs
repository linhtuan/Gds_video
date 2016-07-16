using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Gds.BusinessObject.DbContext;
using Gds.VideoFrontend.Domain;
using Gds.VideoFrontend.Infrastructure;
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
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}