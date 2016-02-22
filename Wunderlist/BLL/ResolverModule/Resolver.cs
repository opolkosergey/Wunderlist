using System.Reflection;
using Autofac;
using BLL.Interfaces;
using BLL.Services;

namespace BLL.ResolverModule
{
    public class Resolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterModule()

            builder.RegisterType<PhotoService>().As<IPhotoService>().InstancePerRequest();
            builder.RegisterType<TodoItemsService>().As<ITodoItemsService>().InstancePerRequest();
            builder.RegisterType<TodoListsService>().As<ITodoListsService>().InstancePerRequest();
            builder.RegisterType<UserProfileService>().As<IUserProfileService>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
