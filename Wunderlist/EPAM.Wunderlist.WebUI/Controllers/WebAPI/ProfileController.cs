using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EPAM.Wunderlist.Model;
using EPAM.Wunderlist.Services.UserProfileService;

namespace EPAM.Wunderlist.WebUI.Controllers.WebAPI
{
    public class ProfileController : Controller
    {
        private readonly IUserProfileService _profileService;

        public ProfileController(IUserProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(UserProfileModel profile)
        {
            _profileService.Update(profile);
            return Json(new {PhotoUrl = profile.Photo,name = profile.Name});
        }
    }
}