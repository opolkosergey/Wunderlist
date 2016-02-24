using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using BLL.ResolverModule;
using Microsoft.AspNet.Identity;
using Wunderlist.IdentityCore;

namespace Wunderlist
{
    public class ResolverConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();
            builder.RegisterModule(new ResolverBll());

            builder.RegisterType<WunderlistIdentityUserStore>().As<IUserStore<WunderlistIdentityUser, int>>().InstancePerRequest();
            builder.RegisterType<WunderlistIdentityUserManager>().InstancePerRequest();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}