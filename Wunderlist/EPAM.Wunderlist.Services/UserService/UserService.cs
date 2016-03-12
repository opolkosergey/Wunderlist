using System;
using System.Collections.Generic;
using System.Linq;
using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.LoggerService;

namespace EPAM.Wunderlist.Services.UserService
{
    public class UserService : BaseService<UserModel>, IUserService
    {
        private readonly IRepository<UserProfileModel> _profileRepository;
        protected override IRepository<UserModel> GetRepository
            => WorkWithMssql.UserRepository;

        public UserService(IUnitOfWork workWithMssql, ILoggerService logger)
            :base(workWithMssql, logger, new [] { "Id", "Profile", "TodoLists", "Password" })
        {
            _profileRepository = workWithMssql.ProfileRepository;
        }

        public void CreateUser(UserModel user, string name)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            if(name == null)
                throw new ArgumentNullException(nameof(name));

            user.Profile = new UserProfileModel
            {
                Name = name,
                Photo = "1.jpg"
            };
            user.TodoLists = new List<TodoListModel>
            {
                new TodoListModel()
                {
                    Name = "Inbox"
                }
            };

            Add(user);
        }
        
        public UserModel GetUserByEmail(string email)
        {
            if (email == null)
                return null;

            return GetRepository.GetAll().FirstOrDefault(p => p.Email == email);
        }

        public override void Remove(int id)
        {
            _profileRepository.Remove(id);
            base.Remove(id);
        }
        
        public override void Update(UserModel user)
        {
            try
            {
                var targerUser = GetById(user.Id);

                if (user.Password != null && user.Password != targerUser.Password)
                    targerUser.Password = user.Password;

                targerUser.Profile.Name = user.Profile.Name;
                ComparisonPropertyValues(user, targerUser);
                GetRepository.Update(targerUser);
                WorkWithMssql.Commit();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
        }
    }
}
