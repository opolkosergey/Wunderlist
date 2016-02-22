using System.Data.Entity;
using Autofac;
using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.ResolverModule
{
    public class ResolverDal : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<WunderlistContext>().As<DbContext>()
                .WithParameter("connect", "WunderlistDB")
                .InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof (UserRepository).Assembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
