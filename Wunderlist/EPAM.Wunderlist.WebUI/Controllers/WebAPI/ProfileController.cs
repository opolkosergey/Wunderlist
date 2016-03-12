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
        public ActionResult UpdateUser(UserProfileModel profile)
        {
            _profileService.Update(profile);
            if(string.IsNullOrEmpty(profile.Photo))
                return Json(new {PhotoUrl = "",name = profile.Name});

            return Json(new { PhotoUrl = profile.Photo, name = profile.Name });
        }

        [HttpGet]
        public ActionResult GetProfile(int id)
        {
            return Json(_profileService.GetById(id),JsonRequestBehavior.AllowGet);
        } 
    }
}