using EPAM.Wunderlist.DataAccess.API;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.LoggerService;

namespace EPAM.Wunderlist.Services.UserProfileService
{
    public class UserProfileService : BaseService<UserProfileModel>, IUserProfileService
    {
        protected override IRepository<UserProfileModel> GetRepository
            => WorkWithMssql.ProfileRepository;
        
        public UserProfileService(IUnitOfWork workWithMssql, ILoggerService logger)
            :base(workWithMssql, logger, new[] { "Id", "UserModel" })
        {

        }
    }
}
