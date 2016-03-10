using System;
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
            : base(workWithMssql, logger, new[] { "Id", "UserModel" })
        {

        }

        public override void Update(UserProfileModel entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.Photo))
                {
                    var targerEntity = GetById(entity.Id);
                    targerEntity.Name = entity.Name;
                    GetRepository.Update(targerEntity);
                    WorkWithMssql.Commit();
                }
                else
                    base.Update(entity);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
        }
    }
}
