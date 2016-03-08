using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.UserService;
using EPAM.Wunderlist.WebUI.IdentityCore;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;
using static EPAM.Wunderlist.WebUI.Mapper.HelperConvert;

namespace EPAM.Wunderlist.WebUI.Controllers.WebAPI
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            if (userService == null)
                throw new ArgumentNullException(nameof(userService));
            
            _userService = userService;
        }

        // Получение информации о пользователе
        [HttpGet]
        public User GetInfoAboutUser()
        {
            var userModel = _userService.GetById(User.Identity.GetUserId<int>());
            var user = EntityConvert<UserModel, User>(userModel);
            user.UserName = userModel.Profile.Name;
            user.Password = null;
            return user;
        }

        // Обновление пользователя по id
        [HttpPost]
        public HttpResponseMessage Put(int id, [FromBody]User user)
        {
            try
            {
                if (user.Password != null)
                    user.Password = Crypto.HashPassword(user.Password);

                var userToUpdate = EntityConvert<User, UserModel>(user);
                userToUpdate.Profile = new UserProfileModel {Name = user.UserName};
                _userService.Update(userToUpdate);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Удаление пользователя по id
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
