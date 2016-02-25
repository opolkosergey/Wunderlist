using System.Data.Entity;
using Autofac;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.DataAccess.MSSQLProvider;
using EPAM.Wunderlist.DataAccess.MSSQLProvider.Context;
using EPAM.Wunderlist.Services.LoggerService;
using EPAM.Wunderlist.Services.PhotoService;
using EPAM.Wunderlist.Services.TodoItemsService;
using EPAM.Wunderlist.Services.TodoListsService;
using EPAM.Wunderlist.Services.UserProfileService;
using EPAM.Wunderlist.Services.UserService;

namespace EPAM.Wunderlist.ResolverModule
{
    public class Resolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
              .InstancePerRequest();

            builder.RegisterType<WunderlistContext>().As<DbContext>()                 
                  .WithParameter("connect", "WunderlistDB")
                  .InstancePerRequest();

            builder.RegisterType<PhotoService>().As<IPhotoService>()
                .InstancePerRequest();

            builder.RegisterType<TodoItemsService>().As<ITodoItemsService>()
                .InstancePerRequest();

            builder.RegisterType<TodoListsService>().As<ITodoListsService>()
                .InstancePerRequest();

            builder.RegisterType<UserProfileService>().As<IUserProfileService>()
                .InstancePerRequest();

            builder.RegisterType<UserService>().As<IUserService>()
                .InstancePerRequest();

            builder.RegisterType<DatabaseLogger>().As<ILogger>()
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
