using Autofac;
using BLL.Interfaces;
using BLL.Services;
using DAL.ResolverModule;

namespace BLL.ResolverModule
{
    public class ResolverBll : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ResolverDal());

            builder.RegisterType<PhotoService>().As<IPhotoService>().InstancePerRequest();
            builder.RegisterType<TodoItemsService>().As<ITodoItemsService>().InstancePerRequest();
            builder.RegisterType<TodoListsService>().As<ITodoListsService>().InstancePerRequest();
            builder.RegisterType<UserProfileService>().As<IUserProfileService>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
