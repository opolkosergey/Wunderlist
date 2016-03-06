using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using EPAM.Wunderlist.ResolverModule;
using EPAM.Wunderlist.WebUI.IdentityCore;
using Microsoft.AspNet.Identity;

namespace EPAM.Wunderlist.WebUI
{
    public class ResolverConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new Resolver());
            builder.RegisterFilterProvider();

            builder.RegisterType<StoreIdentityUser>()
                .As<IUserStore<UserIdentity, int>>()
                .InstancePerRequest();

            builder.RegisterType<ManagerIdentityUser>()
                .As<UserManager<UserIdentity, int>>()
                .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}