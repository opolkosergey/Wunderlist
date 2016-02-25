using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
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
            builder.RegisterFilterProvider();
            builder.RegisterModule(new Resolver());

            builder.RegisterType<StoreIdentityUser>().As<IUserStore<UserIdentity, int>>().InstancePerRequest();
            builder.RegisterType<ManagerIdentityUser>().InstancePerRequest();

            var container = new AutofacDependencyResolver(builder.Build());
            DependencyResolver.SetResolver(container);
        }
    }
}