using System.Data.Entity;
using Autofac;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.MSSQLProvider;
using EPAM.Wunderlist.DataAccess.MSSQLProvider.Context;
using EPAM.Wunderlist.Services.UserService;

namespace EPAM.Wunderlist.ResolverModule
{
    public class Resolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MssqlWorker>().As<IUnitOfWork>()
              .InstancePerRequest();

            builder.RegisterType<WunderlistContext>().As<DbContext>()                 
                  .WithParameter("connect", "WunderlistDB")
                  .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces()
             .InstancePerRequest();
            
            base.Load(builder);
        }
    }
}
